using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;

namespace Sketch_Application
{
    public partial class Canvas : Panel
    {
        private List<Shape> shapes = new List<Shape>();
        private List<Shape> selectedShapes = new List<Shape>();
        private List<Shape> clipBoard = new List<Shape>();
        private bool clear = false;
        public Color Colour = Color.Black;
        public Mode Mode = Mode.Select;

        public Canvas()
            : base()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs p)
        {
            base.OnPaint(p);

            if (this.clear)
            {
                this.clear = false;
                p.Graphics.Clear(Color.White);
                return;
            }

            p.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (Shape shape in this.shapes)
            {
                using (Pen pen = new Pen(shape.Colour, shape.Thickness))
                {
                    shape.Draw(p.Graphics, pen);
                }
            }
        }

        public void AddNewShape(Point position)
        {
            switch (this.Mode) {
                case Mode.Select:
                    Select select = new Select(position);
                    this.shapes.Add(select);
                    break;

                case Mode.FreeHand:
                    FreeLine freeLine = new FreeLine(position, this.Colour);
                    this.shapes.Add(freeLine);
                    break;

                case Mode.Line:
                    Line line = new Line(position, this.Colour);
                    this.shapes.Add(line);
                    break;

                case Mode.Rectangle:
                    Rectangle rectangle = new Rectangle(position, this.Colour);
                    this.shapes.Add(rectangle);
                    break;

                case Mode.Square:
                    Square square = new Square(position, this.Colour);
                    this.shapes.Add(square);
                    break;

                case Mode.Ellipse:
                    Ellipse ellipse = new Ellipse(position, this.Colour);
                    this.shapes.Add(ellipse);
                    break;

                case Mode.Circle:
                    Circle circle = new Circle(position, this.Colour);
                    this.shapes.Add(circle);
                    break;

                case Mode.Polygon:
                    Polygon polygon = new Polygon(position, this.Colour);
                    Line line1 = new Line(position, this.Colour);
                    polygon.addLine(line1);
                    //polygon.addLine(position, this.Colour);
                    this.shapes.Add(polygon);
                    break;

            }

            this.Invalidate(); // Update the canvas
        }

        public void AddToCurrentShape(Point position)
        {
            Shape shape = this.shapes.Last();

            if (shape is Select)
            {
                Select select = (Select)shape;
                select.EndPoint = position;
            }
            else if (shape is FreeLine)
            {
                FreeLine freeLine = (FreeLine)shape;
                freeLine.Points.Add(position);
            }
            else if (shape is Line)
            {
                Line line = (Line)shape;
                line.EndPoint = position;
            }
            else if (shape is Rectangle)
            {
                Rectangle rectangle = (Rectangle)shape;
                rectangle.EndPoint = position;
            }
            else if (shape is Square)
            {
                Square square = (Square)shape;
                square.EndPoint = position;
            }
            else if (shape is Ellipse)
            {
                Ellipse ellipse = (Ellipse)shape;
                ellipse.EndPoint = position;
            }
            else if (shape is Circle)
            {
                Circle circle = (Circle)shape;
                circle.EndPoint = position;
            }
            else if (shape is Polygon)
            {
                Polygon polygon = (Polygon)shape;
                polygon.getCurrentLine().EndPoint = position;
            }

            this.Invalidate(); // Update the canvas
        }

        public bool AddLineToCurrentShape(Point position)
        {
            Shape shape = this.shapes.Last();
            bool isDrawing = true;
                
            if (shape is Polygon)
            {
                Polygon polygon = (Polygon)shape;
                
                if (Math.Abs(polygon.getStartPoint().X - position.X) < 20 && Math.Abs(polygon.getStartPoint().Y - position.Y) < 20)
                {
                    polygon.getCurrentLine().EndPoint = polygon.getStartPoint(); //close polygon
                    polygon.EndPoint = polygon.getStartPoint();
                    isDrawing = false;
                }
                else
                {
                    polygon.getCurrentLine().EndPoint = position;
                    Line line = new Line(position, this.Colour);
                    polygon.addLine(line);
                }

            }
            this.Invalidate(); //update the canvas
            return isDrawing;
        }

        public void SelectShapes()
        {
            Shape shape = this.shapes.Last();

            if (shape is Select)
            {
                Select select = (Select)shape;

                this.RemoveSelect();

                this.selectedShapes = select.FindContainedShapes(this.shapes.Where(x => !(x is Select)).ToList(), this.Width);
            }

            this.Invalidate(); // Update the canvas
        }

        public void Cut()
        {
            this.clipBoard = selectedShapes;
            foreach (Shape s in clipBoard)
            {
                this.shapes.Remove(s);
            }
            this.Invalidate();
        }

        public void Paste(Point startPoint)
        {
            foreach (Shape s in clipBoard)
            {
                if (s is FreeLine)
                {
                    FreeLine freeLine = (FreeLine)s;
                    int minX = 100000;
                    int minY = 100000;

                    foreach (Point p in freeLine.Points)
                    {
                        if (p.X < minX)
                            minX = p.X;
                        if (p.Y < minY)
                            minY = p.Y;
                    }

                    int xD = startPoint.X - minX;
                    int yD = startPoint.Y - minY;

                    int firstX = freeLine.Points.First<Point>().X + xD;
                    int firstY = freeLine.Points.First<Point>().Y + yD;
                    FreeLine newLine = new FreeLine(new Point(firstX, firstY), Color.Black);
                    List<Point> points = new List<Point>();
                    foreach (Point p in freeLine.Points)
                    {
                        newLine.Points.Add(new Point(p.X+xD, p.Y+yD));
                    }
                    this.shapes.Add(newLine);
                }
                else if (s is Line)
                {
                    Line line = (Line)s;

                    int minX = line.StartPoint.X;
                    int minY = line.StartPoint.Y;

                    if (minX > line.EndPoint.X)
                        minX = line.EndPoint.X;
                    if (minY > line.EndPoint.Y)
                        minY = line.EndPoint.Y;

                    /*float midX = (line.StartPoint.X + line.EndPoint.X)/2;
                    float midY = (line.StartPoint.Y + line.EndPoint.Y) / 2;*/

                    int xD = startPoint.X - minX;
                    int yD = startPoint.Y - minY;

                    int firstX = line.StartPoint.X + xD;
                    int firstY = line.StartPoint.Y + yD;

                    Line newLine = new Line(new Point(firstX, firstY), Color.Black);
                    /*int xD = startPoint.X - line.StartPoint.X + line.EndPoint.X;
                    int yD = startPoint.Y - line.StartPoint.Y + line.EndPoint.Y;*/
                    Point newEndPoint = new Point(line.EndPoint.X+xD, line.EndPoint.Y+yD);
                    newLine.EndPoint = newEndPoint;
                    this.shapes.Add(newLine);
                }
                else if (s is Rectangle)
                {
                    Rectangle rectangle = (Rectangle)s;
                    Rectangle newRectangle = new Rectangle(startPoint, Color.Black);
                    int xD = startPoint.X + rectangle.Width;
                    int yD = startPoint.Y + rectangle.Height;
                    Point newEndPoint = new Point(xD, yD);
                    newRectangle.EndPoint = newEndPoint;
                    this.shapes.Add(newRectangle);
                }
                else if (s is Square)
                {
                    Square square = (Square)s;
                    Square newSquare = new Square(startPoint, Color.Black);
                    int xD = startPoint.X - square.StartPointX + square.EndPoint.X;
                    int yD = startPoint.Y - square.StartPointY + square.EndPoint.Y;
                    Point newEndPoint = new Point(xD, yD);
                    newSquare.EndPoint = newEndPoint;
                    this.shapes.Add(newSquare);
                }
                else if (s is Ellipse)
                {
                    Ellipse ellipse = (Ellipse)s;
                    Ellipse newEllipse = new Ellipse(startPoint, Color.Black);
                    int xD = startPoint.X - ellipse.StartPointX + ellipse.EndPoint.X;
                    int yD = startPoint.Y - ellipse.StartPointY + ellipse.EndPoint.Y;
                    Point newEndPoint = new Point(xD, yD);
                    newEllipse.EndPoint = newEndPoint;
                    this.shapes.Add(newEllipse);
                }
                else if (s is Circle)
                {
                    Circle circle = (Circle)s;
                    Circle newCircle = new Circle(startPoint, Color.Black);
                    int xD = startPoint.X - circle.StartPointX + circle.EndPoint.X;
                    int yD = startPoint.Y - circle.StartPointY + circle.EndPoint.Y;
                    Point newEndPoint = new Point(xD, yD);
                    newCircle.EndPoint = newEndPoint;
                    this.shapes.Add(newCircle);
                }
                else if (s is Polygon)
                {
                    Polygon polygon = (Polygon)s;
                    //polygon.getCurrentLine().EndPoint = position;
                }
            }
            this.Invalidate();
        }

        public void ClearCanvas()
        {
            this.clear = true;
            this.shapes.Clear();
            this.Invalidate();
        }

        public void RemoveSelect()
        {
            this.shapes.RemoveAll(x => x is Select);

            foreach (Shape selectedShape in this.selectedShapes)
            {
                selectedShape.isSelected = false;
                selectedShape.Thickness = 1F;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
        public List<Shape> Shapes
        {
            get { return this.shapes; }
            set { this.shapes = value; }
        }
    }
}
