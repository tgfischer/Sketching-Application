﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    [Serializable]
    public class Square : Rectangle
    {
        private int width = 0;
        private int height = 0;

        private Square() { }

        public Square(Point start, Color colour)
            : base(start, colour) { }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawRectangle(pen, this.StartPoint.X, this.StartPoint.Y, this.Width, this.Height);
        }

        public void Fill(Graphics g, Brush brush)
        {
            g.FillRectangle(brush, new System.Drawing.Rectangle(this.StartPoint.X, this.StartPoint.Y, Width, Width));
        }

        public override Point StartPoint
        {
            get 
            {
                int x = 0;
                int y = 0;

                if (this.start.X > this.end.X)
                {
                    x = Math.Min(this.start.X, this.start.X - width); 
                }
                else
                {
                    x = Math.Min(this.start.X, this.start.X + width); 
                }

                if (this.start.Y > this.end.Y)
                {
                    y = Math.Min(this.start.Y, this.start.Y - width);
                }
                else
                {
                    y = Math.Min(this.start.Y, this.start.Y + width);
                }

                return new Point(x, y);
            }
        }

        public override Point EndPoint
        {
            get { return this.end; }
            set
            {
                this.end = value;

                int width = Math.Abs(this.start.X - this.end.X);
                int height = Math.Abs(this.start.Y - this.end.Y);

                this.Width = width < height ? width : height;
                this.Height = height < width ? height : width;
            }
        }

        public override int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public override int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }
    }
}
