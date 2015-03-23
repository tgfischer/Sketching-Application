﻿using System;
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
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(select.StartPointX, select.StartPointY, select.Width, select.Height);

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
            return LineIntersectsRect(line.StartPoint, line.EndPoint, new System.Drawing.Rectangle(select.StartPointX, select.StartPointY, select.Width, select.Height));
        }

        public static bool RectangleIntersectsSelect(Rectangle rectangle, Select select)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(select.StartPointX, select.StartPointY, select.Width, select.Height);

            List<Point> points = new List<Point>();
            points.Add(rectangle.StartPoint);
            points.Add(new Point(rectangle.StartPointX + rectangle.Width, rectangle.StartPointY));
            points.Add(new Point(rectangle.StartPointX, rectangle.StartPointY + rectangle.Height));
            points.Add(new Point(rectangle.StartPointX + rectangle.Width, rectangle.StartPointY + rectangle.Height));


            for (int i = 1; i < points.Count; i++)
            {
                if (LineIntersectsRect(points.ElementAt(i - 1), points.ElementAt(i), rect))
                {
                    return true;
                }
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


    }
}
