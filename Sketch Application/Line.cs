﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    class Line : Shape
    {
        private Point start;
        private Point end;

        public Line(Point start, Color colour)
            : base(colour)
        {
            this.start = start;
            this.end = start;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, start, end);
        }

        public override void Redraw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, start, end);
        }

        // TODO: Validate start is on canvas in the set { }
        public Point StartPoint
        {
            get { return start; }
            set { this.start = value; }
        }

        // TODO: Validate end is on canvas in the set { }
        public Point EndPoint
        {
            get { return end; }
            set { this.end = value; }
        }
    }
}
