using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    [Serializable]
    public class Circle : Ellipse
    {
        private int width = 0;
        private int height = 0;

        private Circle() { }

        public Circle(Point start, Color colour)
            : base(start, colour) {}

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawEllipse(pen, this.StartPoint.X, this.StartPoint.Y, this.Diameter, this.Diameter);
        }

        public override Point StartPoint
        {
            get
            {
                int x = 0;
                int y = 0;

                if (this.start.X > this.end.X)
                {
                    x = Math.Min(this.start.X, this.start.X - width);
                }
                else
                {
                    x = Math.Min(this.start.X, this.start.X + width);
                }

                if (this.start.Y > this.end.Y)
                {
                    y = Math.Min(this.start.Y, this.start.Y - width);
                }
                else
                {
                    y = Math.Min(this.start.Y, this.start.Y + width);
                }

                return new Point(x, y);
            }
        }

        public int Diameter
        {
            get
            {
                if (Math.Abs(this.start.X - this.end.X) <= Math.Abs(this.start.Y - this.end.Y))
                {
                    return Math.Abs(this.start.X - this.end.X);
                }
                else
                    return Math.Abs(this.start.Y - this.end.Y);
            }
        }

        public override Point EndPoint
        {
            get { return this.end; }
            set
            {
                this.end = value;

                int width = Math.Abs(this.start.X - this.end.X);
                int height = Math.Abs(this.start.Y - this.end.Y);

                this.width = width < height ? width : height;
                this.height = height < width ? height : width;

                if (this.width > this.height)
                    this.end.X = this.start.X + this.height;
                else if (this.height > this.width)
                    this.end.Y = this.start.Y + this.width;

            }
        }
    }
}
