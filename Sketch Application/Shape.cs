using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;

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

        [XmlIgnore]
        public Color Colour
        {
            get { return this.isSelected ? Color.Blue : this.colour; }
            set { this.colour = value; }
        }

        [XmlElement("Colour")]
        public string HtmlColour
        {
            get { return ColorTranslator.ToHtml(this.Colour); }
            set { this.Colour = ColorTranslator.FromHtml(value); }
        }

        public abstract void Draw(Graphics g, Pen pen);

        public abstract void Shift(int x, int y);

        public abstract Point UpperLeftPoint
        {
            get;
        }
    }
}
