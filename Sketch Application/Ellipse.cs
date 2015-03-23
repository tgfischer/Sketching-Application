using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    class Ellipse : Shape
    {
        protected Point start;
        protected Point end;

        public Ellipse(Point start, Color colour)
            : base(colour)
        {
            this.start = start;
            this.end = start;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawEllipse(pen, this.StartPointX, this.StartPointY, this.Width, this.Height);
        }

        public int StartPointX
        {
            get { return Math.Min(this.start.X, this.end.X); }
        }

        public int StartPointY
        {
            get { return Math.Min(this.start.Y, this.end.Y); }
        }

        public int Width
        {
            get { return Math.Abs(this.start.X - this.end.X); }
        }

        public int Height
        {
            get { return Math.Abs(this.start.Y - this.end.Y); }
        }

        public virtual Point EndPoint
        {
            set { this.end = value; }
        }
    }
}
