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
            if (this.shapes.Count == 0)
                return;

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
            if (this.shapes.Count == 0)
                return false;

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
            if (this.shapes.Count() == 0)
                return;

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

                    int xD = startPoint.X - freeLine.UpperLeftPoint.X;
                    int yD = startPoint.Y - freeLine.UpperLeftPoint.Y;

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
                else if (s is GroupedShape)
                {
                    GroupedShape gShape = (GroupedShape)s;

                    int xD = startPoint.X - gShape.UpperLeftPoint.X;
                    int yD = startPoint.Y - gShape.UpperLeftPoint.Y;

                    foreach (Shape sh in gShape.Shapes)
                    {
                        if (sh is FreeLine)
                        {
                            FreeLine freeLine = (FreeLine)sh;
                            int firstX = freeLine.Points.First<Point>().X + xD;
                            int firstY = freeLine.Points.First<Point>().Y + yD;
                            FreeLine newLine = new FreeLine(new Point(firstX, firstY), Color.Black);
                            List<Point> points = new List<Point>();
                            foreach (Point p in freeLine.Points)
                            {
                                newLine.Points.Add(new Point(p.X + xD, p.Y + yD));
                            }
                            this.shapes.Add(newLine);
                        }
                        else if (s is Line)
                        {
                            Line line = (Line)sh;
                            int firstX = line.StartPoint.X + xD;
                            int firstY = line.StartPoint.Y + yD;
                            Line newLine = new Line(new Point(firstX, firstY), Color.Black);
                            Point newEndPoint = new Point(line.EndPoint.X + xD, line.EndPoint.Y + yD);
                            newLine.EndPoint = newEndPoint;
                            this.shapes.Add(newLine);
                        }
                        this.shapes.Add(sh);
                    }
                }
                else if (s is Line)
                {
                    Line line = (Line)s;

                    int xD = startPoint.X - line.UpperLeftPoint.X;
                    int yD = startPoint.Y - line.UpperLeftPoint.Y;

                    int firstX = line.StartPoint.X + xD;
                    int firstY = line.StartPoint.Y + yD;

                    Line newLine = new Line(new Point(firstX, firstY), Color.Black);
                    Point newEndPoint = new Point(line.EndPoint.X+xD, line.EndPoint.Y+yD);
                    newLine.EndPoint = newEndPoint;
                    this.shapes.Add(newLine);
                }
                else if (s is Rectangle)
                {
                    Rectangle rectangle = (Rectangle)s;

                    int xD = startPoint.X - rectangle.UpperLeftPoint.X;
                    int yD = startPoint.Y - rectangle.UpperLeftPoint.Y;

                    int firstX = startPoint.X;// +xD;
                    int firstY = startPoint.Y;// +yD;

                    Rectangle newRectangle = new Rectangle(new Point(firstX, firstY), Color.Black);
                    
                    Point newEndPoint = new Point(rectangle.EndPoint.X+xD, rectangle.EndPoint.Y+yD);
                    newRectangle.EndPoint = newEndPoint;
                    this.shapes.Add(newRectangle);
                }
                else if (s is Square)
                {
                    Square square = (Square)s;

                    int xD = startPoint.X - square.UpperLeftPoint.X;
                    int yD = startPoint.Y - square.UpperLeftPoint.Y;

                    int firstX = square.StartPoint.X;// +xD;
                    int firstY = square.StartPoint.Y;// +yD;

                    Square newSquare = new Square(new Point(firstX, firstY), Color.Black);
                    Point newEndPoint = new Point(square.EndPoint.X + xD, square.EndPoint.Y + yD);
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
