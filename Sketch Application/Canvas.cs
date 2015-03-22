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
        {
            InitializeComponent();

            this.shapes = new List<Shape>();
            this.pen = new Pen(this.Colour, 2F);
        }

        public void AddShape(Point position)
        {
            switch (this.Mode) {
                case Mode.FreeHand:
                    break;
                case Mode.Line:
                    Line line = new Line(position);
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
            foreach (Shape shape in this.shapes) {
                shape.Draw();
            }
        }
    }
}
