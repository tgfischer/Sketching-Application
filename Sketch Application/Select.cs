using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    class Select : Shape
    {
        public List<Point> Points;                                  // A list that stores all of the points in the line

        public Select(Point start, Color colour)
            : base(colour)
        {
            this.Points = new List<Point>();                        // Create a new list of points
            this.Points.Add(start);                                 // Add the first point to the list
        }

        public override void Draw(Graphics g, Pen pen)
        {
            if (this.Points.Count > 3)                              // Make sure there is more than 1 point in the list
            {
                g.DrawLines(pen, this.Points.ToArray());            // Draw a curve between these points
            }
        }
    }
}
