using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    class FreeLine : Shape
    {
        public List<Point> Points;

        public FreeLine(Point start, Color colour)
            : base(colour)
        {
            this.Points = new List<Point>();
            this.Points.Add(start);
        }

        public override void Draw(Graphics g, Pen pen)
        {
            if (this.Points.Count > 1)
            {
                for (var i = 1; i < this.Points.Count; i++)
                {
                    g.DrawLine(pen, this.Points.ElementAt(i - 1), this.Points.ElementAt(i));
                }
            }
            else
            {
                g.DrawLine(pen, this.Points.Last(), this.Points.Last());
            }
        }
    }
}
