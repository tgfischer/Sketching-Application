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

namespace Sketch_Application
{
    public partial class Canvas : Panel
    {
        private List<Shape> shapes;
        private Shape selectedShape;
        private Shape clipBoard;
        private bool clear = false;
        public Color Colour = Color.Black;
        public Mode Mode = Mode.Select;

        public Canvas()
            : base()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.shapes = new List<Shape>();
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

            using (Pen pen = new Pen(this.Colour, 1F))
            {
                foreach (Shape shape in this.shapes)
                {
                    pen.Color = shape.Colour;
                    shape.Draw(p.Graphics, pen);
                }
            }
        }

        public void AddNewShape(Point position)
        {
            this.shapes.RemoveAll(x => x is Select);

            switch (this.Mode) {
                case Mode.Select:
                    Select select = new Select(position, this.Colour);
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
                select.Points.Add(position);
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

        public void AddLineToCurrentShape(Point position)
        {
            Shape shape = this.shapes.Last();

            if (shape is Polygon)
            {
                Polygon polygon = (Polygon)shape;
                
                if (Math.Abs(polygon.getStartPoint().X - position.X) < 20 && Math.Abs(polygon.getStartPoint().Y - position.Y) < 20)
                {
                    Console.WriteLine("within range");
                    Console.WriteLine(position);
                    Console.WriteLine(polygon.getStartPoint());
                    polygon.getCurrentLine().EndPoint = polygon.getStartPoint(); //close polygon
                    polygon.EndPoint = polygon.getStartPoint();
                    //polygon.EndPoint = polygon.getStartPoint();
                    
                }
                else
                {
                    polygon.getCurrentLine().EndPoint = position;
                    Line line = new Line(position, this.Colour);
                    polygon.addLine(line);
                }

            }

            this.Invalidate(); // Update the canvas
        }

        public void CloseCurrentShape(Point position)
        {
            Shape shape = this.shapes.Last();

            if (shape is Select)
            {
                Select select = (Select)shape;
                select.Points.Add(select.Points.First());
            }

            this.Invalidate(); // Update the canvas
        }

        public void Cut()
        {
            this.clipBoard = selectedShape;
            this.shapes.Remove(selectedShape);
        }

        public void Paste(Point startPoint)
        {
            this.shapes.Add(this.clipBoard);
        }

        public void ClearCanvas()
        {
            this.clear = true;
            this.shapes.Clear();
            this.Invalidate();
        }
    }
}
