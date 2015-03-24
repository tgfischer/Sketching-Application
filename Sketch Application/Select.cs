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

        public Select(Point start)
            : base(start, Color.Red)
        { }

        public List<Shape> FindContainedShapes(List<Shape> shapes, int width)
        {
            List<Shape> selectedShapes = new List<Shape>();

            foreach (Shape shape in shapes)
            {
                if (this.Contains(shape, width))
                {
                    shape.Thickness = thickness;
                    shape.isSelected = true;
                    selectedShapes.Add(shape);
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

            return false;
        }
    }
}
