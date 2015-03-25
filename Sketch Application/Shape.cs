using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    public abstract class Shape
    {
        protected Color colour = Color.Black;
        public bool isSelected = false;
        public float Thickness = 1F;

        protected Shape() { }

        public Shape(Color colour)
        {
            this.colour = colour;
        }

        public Color Colour
        {
            get { return this.isSelected ? Color.Blue : this.colour; }
            set { this.colour = value; }
        }

        public string HtmlColour
        {
            get { return ColorTranslator.ToHtml(this.Colour); }
            set { this.Colour = ColorTranslator.FromHtml(value); }
        }

        public abstract void Draw(Graphics g, Pen pen);
    }
}
