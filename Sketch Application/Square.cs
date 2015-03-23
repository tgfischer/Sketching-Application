﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    class Square : Rectangle
    {
        private int width = 0;
        private int height = 0;

        public Square(Point start, Color colour)
            : base(start, colour) { }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawRectangle(pen, this.StartPointX, this.StartPointY, this.width, this.height);
        }

        public override int StartPointX
        {
            get 
            { 
                if (this.start.X > this.end.X)
                {
                    return Math.Min(this.start.X, this.start.X - width); 
                }
                else
                {
                    return Math.Min(this.start.X, this.start.X + width); 
                }
            }
        }

        public override int StartPointY
        {
            get 
            {
                if (this.start.Y > this.end.Y)
                {
                    return Math.Min(this.start.Y, this.start.Y - width);
                }
                else
                {
                    return Math.Min(this.start.Y, this.start.Y + width);
                } 
            }
        }

        public override Point EndPoint
        {
            set 
            {
                this.end = value;

                int width = Math.Abs(this.start.X - this.end.X);
                int height = Math.Abs(this.start.Y - this.end.Y);

                this.width = width < height ? width : height;
                this.height = height < width ? height : width;
            }
        }
    }
}
