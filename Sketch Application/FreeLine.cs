using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    [Serializable]
    public class FreeLine : Shape
    {
        public List<Point> Points;                                  // A list that stores all of the points in the line
        private const int smoothness = 3;                           // Higher number = smoother the curve. Default = 1

        private FreeLine() { }

        public FreeLine(Point start, Color colour)
            : base(colour)
        {
            this.Points = new List<Point>();                        // Create a new list of points
            this.Points.Add(start);                                 // Add the first point to the list
        }

        public override void Draw(Graphics g, Pen pen)
        {
            if (this.Points.Count > smoothness)                     // Make sure there is enough points in the list
            {
                // Draw a curve using every nth point in the list
                g.DrawCurve(pen, this.Points.Where((x, i) => i % smoothness == 0).ToArray());
            }
            else if (this.Points.Count > 1)                         // Make sure there is more than 1 point in the list
            {
                g.DrawCurve(pen, this.Points.ToArray());            // Draw a curve between these points
            }
            else                                                    // If there is only one point in the list
            {
                using (Brush brush = new SolidBrush(this.Colour))   // Since apparently Pen doesn't support drawing single pixels...
                {
                    // Draw 1 single pixel
                    g.FillRectangle(brush, this.Points.First().X, this.Points.First().Y, 1, 1);
                }
            }

            // FOR SPEED
            /*if (this.Points.Count > 1)                         // Make sure there is more than 1 point in the list
            {
                g.DrawLines(pen, this.Points.ToArray());            // Draw a curve between these points
            }
            else                                                    // If there is only one point in the list
            {
                using (Brush brush = new SolidBrush(this.Colour))   // Since apparently Pen doesn't support drawing single pixels...
                {
                    // Draw 1 single pixel
                    g.FillRectangle(brush, this.Points.First().X, this.Points.First().Y, 1, 1);
            }
            }*/

            // FOR COOLNESS
            /*int webbing = 4;
            if (this.Points.Count > webbing)
            {
                for (int i = webbing; i < this.Points.Count; i++)
                {
                    for (int j = i; j > i - webbing; j--)
                    {
                        g.DrawLine(pen, this.Points.ElementAt(i), this.Points.ElementAt(j));
                    }
                }
            }
            else if (this.Points.Count > 1)
            {
                g.DrawLines(pen, this.Points.ToArray());
            }
            else
            {
                using (Brush brush = new SolidBrush(this.Colour))
                {
                    g.FillRectangle(brush, this.Points.First().X, this.Points.First().Y, 1, 1);
                }
            }*/
        }

        public override void Shift(int x, int y)
        {
            List<Point> points = new List<Point>();
            //create new freeline and store in temp list
            foreach (Point p in this.Points)
            {
                points.Add(new Point(p.X + x, p.Y + y));
            }
            //draw new line and erase old
            foreach (Point p in points)
            {
                this.Points.Remove(new Point(p.X - x, p.Y - y));
                this.Points.Add(p);
            }
        }

        public override Point UpperLeftPoint
        {
            get 
            {
                int x = Int32.MaxValue;
                int y = Int32.MaxValue;

                foreach (Point p in this.Points)
                    {
                        if (p.X < x)
                            x = p.X;
                        if (p.Y < y)
                            y = p.Y;
                    }

                return new Point(x, y);
            }
        }
    }
}
