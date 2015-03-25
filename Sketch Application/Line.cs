using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    public class Line : Shape
    {
        private Point start;
        private Point end;

        private Line() { }

        public Line(Point start, Color colour)
            : base(colour)
        {
            this.start = start;
            this.end = start;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, this.start, this.end);
        }

        public Point StartPoint
        {
            get { return this.start; }
            set { this.start = value; }
        }

        public Point EndPoint
        {
            get { return this.end; }
            set { this.end = value; }
        }

        public override Point UpperLeftPoint
        {
            get
            {
                int x = Int32.MaxValue;
                int y = Int32.MaxValue;

                if (this.EndPoint.X < x)
                    x = this.EndPoint.X;
                if (this.EndPoint.Y < y)
                    y = this.EndPoint.Y;
                if (this.StartPoint.X < x)
                    x = this.StartPoint.X;
                if (this.StartPoint.Y < y)
                    y = this.StartPoint.Y;

                return new Point(x, y);
            }
        }
    }
}
