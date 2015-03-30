using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    public static class Geometry
    {
        public static bool FreeLineIntersectsSelect(FreeLine freeLine, Select select)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(select.StartPoint.X, select.StartPoint.Y, select.Width, select.Height);

            for (int i = 1; i < freeLine.Points.Count; i++)
            {
                if (LineIntersectsRect(freeLine.Points.ElementAt(i - 1), freeLine.Points.ElementAt(i), rect))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool LineIntersectsSelect(Line line, Select select)
        {
            return LineIntersectsRect(line.StartPoint, line.EndPoint, new System.Drawing.Rectangle(select.StartPoint.X, select.StartPoint.Y, select.Width, select.Height));
        }

        public static bool RectangleIntersectsSelect(Rectangle rectangle, Select select)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(select.StartPoint.X, select.StartPoint.Y, select.Width, select.Height);

            List<Point> points = new List<Point>();
            points.Add(rectangle.StartPoint);
            points.Add(new Point(rectangle.StartPoint.X + rectangle.Width, rectangle.StartPoint.Y));
            points.Add(new Point(rectangle.StartPoint.X + rectangle.Width, rectangle.StartPoint.Y + rectangle.Height));
            points.Add(new Point(rectangle.StartPoint.X, rectangle.StartPoint.Y + rectangle.Height));


            for (int i = 1; i < points.Count; i++)
            {
                if (LineIntersectsRect(points.ElementAt(i - 1), points.ElementAt(i), rect))
                {
                    return true;
                }
            }

            if (LineIntersectsRect(points.Last(), points.First(), rect))
            {
                return true;
            }

            return false;
        }

        public static bool LineIntersectsRect(Point p1, Point p2, System.Drawing.Rectangle r)
        {
            return LineIntersectsLine(p1, p2, new Point(r.X, r.Y), new Point(r.X + r.Width, r.Y)) ||
                   LineIntersectsLine(p1, p2, new Point(r.X + r.Width, r.Y), new Point(r.X + r.Width, r.Y + r.Height)) ||
                   LineIntersectsLine(p1, p2, new Point(r.X + r.Width, r.Y + r.Height), new Point(r.X, r.Y + r.Height)) ||
                   LineIntersectsLine(p1, p2, new Point(r.X, r.Y + r.Height), new Point(r.X, r.Y)) ||
                   (r.Contains(p1) && r.Contains(p2));
        }

        private static bool LineIntersectsLine(Point l1p1, Point l1p2, Point l2p1, Point l2p2)
        {
            float q = (l1p1.Y - l2p1.Y) * (l2p2.X - l2p1.X) - (l1p1.X - l2p1.X) * (l2p2.Y - l2p1.Y);
            float d = (l1p2.X - l1p1.X) * (l2p2.Y - l2p1.Y) - (l1p2.Y - l1p1.Y) * (l2p2.X - l2p1.X);

            if (d == 0)
            {
                return false;
            }

            float r = q / d;

            q = (l1p1.Y - l2p1.Y) * (l1p2.X - l1p1.X) - (l1p1.X - l2p1.X) * (l1p2.Y - l1p1.Y);
            float s = q / d;

            if (r < 0 || r > 1 || s < 0 || s > 1)
            {
                return false;
            }

            return true;
        }

        public static bool EllipseIntersectsSelect(Ellipse ellipse, Select select)
        {
            System.Drawing.Rectangle ellRect = new System.Drawing.Rectangle(ellipse.UpperLeftPoint.X, ellipse.UpperLeftPoint.Y, ellipse.Width, ellipse.Height);

            float cx = ellRect.Left + ellRect.Width / 2f;
            float cy = ellRect.Top + ellRect.Height / 2f;
            ellRect.X = ellRect.Left - (int)cx;
            ellRect.Y = ellRect.Top - (int)cy;

            float a = ellRect.Width / 2;
            float b = ellRect.Height / 2;
            
            List<Point> points = new List<Point>();
            points.Add(new Point(select.StartPoint.X - (int)cx, select.StartPoint.Y - (int)cy));
            points.Add(new Point(select.StartPoint.X + select.Width - (int)cx, select.StartPoint.Y - (int)cy));
            points.Add(new Point(select.StartPoint.X + select.Width - (int)cx, select.StartPoint.Y + select.Height - (int)cy));
            points.Add(new Point(select.StartPoint.X - (int)cx, select.StartPoint.Y + select.Height - (int)cy));

            for (int i = 1; i < points.Count; i++)
            {
                if (LineIntersectsEllipse(points.ElementAt(i - 1), points.ElementAt(i), a, b))
                {
                    return true;
                }
            }

            if (LineIntersectsEllipse(points.Last(), points.First(), a, b))
            {
                return true;
            }

            if (LineIntersectsEllipse(points.First(), points.ElementAt(2), a, b))
                return true;

            return false;
        }

        public static bool LineIntersectsEllipse(Point pt1, Point pt2, float a, float b)
        {

            // Calculate the quadratic parameters.
            float A = (pt2.X - pt1.X) * (pt2.X - pt1.X) / a / a + (pt2.Y - pt1.Y) * (pt2.Y - pt1.Y) / b / b;
            float B = 2 * pt1.X * (pt2.X - pt1.X) / a / a + 2 * pt1.Y * (pt2.Y - pt1.Y) / b / b;
            float C = pt1.X * pt1.X / a / a + pt1.Y * pt1.Y / b / b - 1;

            // Calculate the discriminant.
            float discriminant = B * B - 4 * A * C;

            List<float> t_values = new List<float>();

            if (discriminant == 0)
            {
                // One real solution.
                t_values.Add(-B / 2 / A);
            }
            else if (discriminant > 0)
            {
                // Two real solutions.
                t_values.Add((float)((-B + Math.Sqrt(discriminant)) / 2 / A));
                t_values.Add((float)((-B - Math.Sqrt(discriminant)) / 2 / A));
            }

            // Convert the t values into points.
            List<PointF> points = new List<PointF>();
            foreach (float t in t_values)
           {
                if (t >= 0f && t <= 1f)
                {
                    return true;
                }
            }

           // Return the points.
            return false;
        }
    }
}
