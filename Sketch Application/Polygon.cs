using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    class Polygon : Shape
    {
        private Point start;
        private Point end;

        public Polygon(Point start, Color colour)
            : base(colour)
        {
            this.start = start;
            this.end = start;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, this.start, this.end);
        }

        public virtual Point EndPoint
        {
            set { this.end = value; }
        }
    }
}
