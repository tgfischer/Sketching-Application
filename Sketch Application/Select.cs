using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    public class Select : Rectangle
    {
        private const float thickness = 2F;
        public Color FillColour = Color.FromArgb(128, 0, 136, 255);

        public Select(Point start)
            : base(start, Color.FromArgb(255, 0, 65, 122))
        { }

        public void Draw(Graphics g, Brush brush)
        {
            g.FillRectangle(brush, this.StartPoint.X, this.StartPoint.Y, this.Width, this.Height);
        }

        public GroupedShape FindContainedShapes(List<Shape> shapes, int width)
        {
            GroupedShape selectedShapes = new GroupedShape();

            foreach (Shape shape in shapes)
            {
                if (this.Contains(shape, width))
                {
                    shape.Select();
                    selectedShapes.Shapes.Add(shape);
                }
            }

            return selectedShapes;
        }

        public bool Contains(Shape shape, int width)
        {
            if (shape is FreeLine)
            {
                return Geometry.FreeLineIntersectsSelect((FreeLine)shape, this);
            }
            else if (shape is Line)
            {
                return Geometry.LineIntersectsSelect((Line)shape, this);
            }
            else if (shape is Rectangle || shape is Square)
            {
                return Geometry.RectangleIntersectsSelect((Rectangle)shape, this);
            }
            else if (shape is Polygon)
            {
                bool isSelected = false;
                Polygon selectedP = (Polygon)shape;

                foreach (Line line in selectedP.lines)
                {
                    isSelected = Geometry.LineIntersectsSelect(line, this);

                    if (isSelected == true)
                        break;
                }

                return isSelected;
            }
            else if (shape is GroupedShape)
            {
                GroupedShape groupedShape = (GroupedShape)shape;

                foreach (Shape subShape in groupedShape.Shapes)
                {
                    if (this.Contains(subShape, width))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
