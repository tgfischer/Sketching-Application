﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    public class Line : Shape
    {
        private Point start;
        private Point end;

        private Line() { }

        public Line(Point start, Color colour)
            : base(colour)
        {
            this.start = start;
            this.end = start;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, this.start, this.end);
        }

        public override void Shift(int x, int y)
        {

        }

        public Point StartPoint
        {
            get { return this.start; }
            set { this.start = value; }
        }

        public Point EndPoint
        {
            get { return this.end; }
            set { this.end = value; }
        }

        public override Point UpperLeftPoint
        {
            get
            {
                return new Point(0, 0);
            }
        }
    }
}
