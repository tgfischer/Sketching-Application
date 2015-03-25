using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    public class Rectangle : Shape
    {
        protected Point start;
        protected Point end;

        protected Rectangle() { }

        public Rectangle(Point start, Color colour)
            : base(colour)
        {
            this.start = start;
            this.end = start;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawRectangle(pen, this.StartPoint.X, this.StartPoint.Y, this.Width, this.Height);
        }

        public override void Shift(int x, int y)
        {
            this.start.X += x;
            this.start.Y += y;
            this.end.X += x;
            this.end.Y += y;
        }

        public virtual Point StartPoint
        {
            get { return new Point(Math.Min(this.start.X, this.end.X), Math.Min(this.start.Y, this.end.Y)); }
            set { this.start = value; }
        }

        public virtual Point EndPoint
        {
            get { return this.end; }
            set { this.end = value; }
        }

        public virtual int Width
        {
            get { return Math.Abs(this.start.X - this.end.X); }
            set { }
        }

        public virtual int Height
        {
            get { return Math.Abs(this.start.Y - this.end.Y); }
            set { }
        }

        public override Point UpperLeftPoint
        {
            get
            {
                return this.StartPoint;
            }
        }
    }
}
