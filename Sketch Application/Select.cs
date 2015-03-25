﻿using System;
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
