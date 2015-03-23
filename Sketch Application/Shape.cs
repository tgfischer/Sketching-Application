﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    public abstract class Shape
    {
        protected Color colour;

        public Shape(Color colour)
        {
            this.colour = colour;
        }

        public Color Colour
        {
            get { return this.colour; }
        }

        public abstract void Draw(Graphics g, Pen pen);

        // public void Add(Shape shape);
        // public void Remove(Shape shape);
        // public Shape GetChild(Shape shape);
    }
}
