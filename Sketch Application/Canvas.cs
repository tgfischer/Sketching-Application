using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sketch_Application
{
    public partial class Canvas : Panel
    {
        private List<Shape> shapes;
        private Shape selectedShape;
        private Shape clipBoard;
        private Graphics g;
        private Pen pen;
        public Color Colour = Color.Black;
        public Mode Mode = Mode.Select;

        public Canvas()
            : base()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.shapes = new List<Shape>();
            this.pen = new Pen(this.Colour, 2F);
        }

        public void AddNewShape(Point position)
        {
            this.g = this.CreateGraphics();

            switch (this.Mode) {
                case Mode.FreeHand:
                    break;
                case Mode.Line:
                    Line line = new Line(position, this.Colour);
                    line.Draw(this.g, this.pen);
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
            
            if (shape is Line) {
                Line line = (Line)shape;
                pen.Color = Color.White;
                line.Draw(g, pen);
                pen.Color = line.Colour;
                line.EndPoint = position;
                line.Draw(g, pen);
            }
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

        public void RefreshCanvas()
        {
            this.ClearCanvas();

            foreach (Shape shape in this.shapes) {
                //shape.Draw();
            }
        }

        public void ClearCanvas()
        {
            this.Refresh();
        }
    }
}
