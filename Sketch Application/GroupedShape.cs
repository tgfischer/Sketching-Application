using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    class GroupedShape : Shape
    {
        public List<Shape> Shapes = new List<Shape>();

        public GroupedShape()
        {

        }

        public override void Draw(Graphics g, Pen pen)
        {
            foreach (Shape shape in this.Shapes)
            {
                shape.Draw(g, pen);
            }
        }

        public override Point UpperLeftPoint
        {
            get 
            {
                int x = Int32.MaxValue;
                int y = Int32.MaxValue;

                foreach (Shape shape in this.Shapes)
                {
                    if (shape.UpperLeftPoint.X < x)
                    {
                        x = shape.UpperLeftPoint.X;
                    }

                    if (shape.UpperLeftPoint.Y < y)
                    {
                        y = shape.UpperLeftPoint.Y;
                    }
                }

                return new Point(x, y);
            }
        }
    }
}
