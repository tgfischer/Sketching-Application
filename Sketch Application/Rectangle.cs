using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;

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
            g.DrawRectangle(pen, this.StartPointX, this.StartPointY, this.Width, this.Height);
        }

        public Point StartPoint
        {
            get { return new Point(this.StartPointX, this.StartPointY); }
            set { this.start = value; }
        }

        public virtual Point EndPoint
        {
            get { return this.end; }
            set { this.end = value; }
        }

        public virtual int StartPointX
        {
            get { return Math.Min(this.start.X, this.end.X); }
        }

        public virtual int StartPointY
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
    }
}
