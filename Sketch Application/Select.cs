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

        public Select(Point start)
            : base(Color.Red)
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

        public List<Shape> FindContainedShapes(List<Shape> shapes, int width)
        {
            List<Shape> containedShapes = new List<Shape>();

            foreach(Shape shape in shapes)
            {
                if (this.Contains(shape, width))
                {
                    containedShapes.Add(shape);
                }
            }

            return containedShapes;
        }

        public bool Contains(Shape shape, int width)
        {
            if (shape is FreeLine)
            {
                FreeLine line = (FreeLine)shape;

                foreach (Point a1 in line.Points)
                {
                    int counter = 0;

                    for (int i = 1; i < this.Points.Count; i++)
                    {
                        // http://www.geeksforgeeks.org/check-if-two-given-line-segments-intersect/

                        Point a2 = new Point(width, a1.Y);
                        Point b1 = this.Points.ElementAt(i - 1);
                        Point b2 = this.Points.ElementAt(i);

                        int o1 = this.Orientation(a1, b1, a2);
                        int o2 = this.Orientation(a1, b1, b2);
                        int o3 = this.Orientation(a2, b2, a1);
                        int o4 = this.Orientation(a2, b2, b1);

                        bool intersects = false;

                        if (o1 != o2 && o3 != o4)
                        {
                            intersects = true;
                        }
                        else if (o1 == 0 && this.OnSegment(a1, a2, b1))
                        {
                            intersects = true;
                        }
                        else if (o2 == 0 && this.OnSegment(a1, b2, b1))
                        {
                            intersects = true;
                        }
                        else if (o3 == 0 && this.OnSegment(a2, a1, b2))
                        {
                            intersects = true;
                        }
                        else if (o4 == 0 && this.OnSegment(a2, b1, b2))
                        {
                            intersects = true;
                        }

                        if (intersects)
                        {
                            counter++;
                        }
                    }

                    if (counter > 0 && counter % 2 != 0) return true;
                }
            }

            return false;
        }

        private int Orientation(Point p, Point q, Point r)
        {
            int value = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);

            if (value == 0)
            {
                return 0;  // colinear
            }

            return (value > 0) ? 1 : 2;
        }

        private bool OnSegment(Point p, Point q, Point r)
        {
            if (q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) && q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y))
            {
                return true;
            }

            return false;
        }
    }
}
