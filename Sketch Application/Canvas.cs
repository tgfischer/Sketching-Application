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

            p.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(this.Colour, 2F))
            {
                foreach (Shape shape in this.shapes)
                {
                    pen.Color = shape.Colour;
                    shape.Redraw(p.Graphics, pen);
                }
            }
        }

        public void AddNewShape(Point position)
        {
            switch (this.Mode) {
                case Mode.FreeHand:
                    FreeLine freeLine = new FreeLine(position, this.Colour);
                    this.shapes.Add(freeLine);

                    break;
                case Mode.Line:
                    Line line = new Line(position, this.Colour);
                    this.shapes.Add(line);

                    break;
                case Mode.Rectangle:
                    break;
                case Mode.Square:
                    break;
                case Mode.Ellipse:
                    break;
                case Mode.Circle:
                    break;
                case Mode.Polygon:
                    break;
            }
        }

        public void AddToCurrentShape(Point position)
        {
            Shape shape = this.shapes.Last();
            
            if (shape is FreeLine)
            {
                FreeLine freeLine = (FreeLine)shape;
                freeLine.Points.Add(position);
            }
            else if (shape is Line) 
            {
                Line line = (Line)shape;
                line.EndPoint = position;
            }

            this.Invalidate(); // Update the canvas
        }

        public void Cut()
        {
            this.clipBoard = selectedShape;
            this.shapes.Remove(selectedShape);
        }

        public void Paste()
        {
            this.shapes.Add(this.clipBoard);
        }
    }
}
