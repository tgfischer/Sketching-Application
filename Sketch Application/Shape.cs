using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;

namespace Sketch_Application
{
    [Serializable]
    public abstract class Shape
    {
        protected Color colour = Color.Black;
        public bool IsSelected = false;
        public float Thickness = 1F;

        protected Shape() { }

        public Shape(Color colour)
        {
            this.colour = colour;
        }

        public void Select()
        {
            this.IsSelected = true;
            this.Thickness = 2F;
        }

        public void Deselect()
        {
            this.IsSelected = false;
            this.Thickness = 1F;
        }

        [XmlIgnore]
        public Color Colour
        {
            get { return this.IsSelected ? Color.FromArgb(255, 0, 65, 122) : this.colour; }
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
