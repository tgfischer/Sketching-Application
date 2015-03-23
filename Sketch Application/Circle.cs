using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    class Circle : Shape
    {
        protected Point start;
        protected Point end;

        public Circle(Point start, Color colour)
            : base(colour)
        {
            this.start = start;
            this.end = start;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawEllipse(pen, this.StartPointX, this.StartPointY, this.Diameter, this.Diameter);
        }

        public int StartPointX
        {
            get { return Math.Min(this.start.X, this.end.X); }
        }

        public int StartPointY
        {
            get { return Math.Min(this.start.Y, this.end.Y); }
        }

        public int Diameter
        {
            get
            {
                if (Math.Abs(this.start.X - this.end.X) <= Math.Abs(this.start.X - this.end.X))
                {
                    return Math.Abs(this.start.X - this.end.X);
                }
                else
                    return Math.Abs(this.start.X - this.end.X);
            }
        }

        // TODO: Validate end is on canvas in the set { }
        public virtual Point EndPoint
        {
            set { this.end = value; }
        }
    }
}
