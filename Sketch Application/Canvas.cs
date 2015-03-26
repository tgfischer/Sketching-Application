using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;

namespace Sketch_Application
{
    public partial class Canvas : Panel
    {
        private List<Shape> shapes = new List<Shape>();
        private GroupedShape selectedShapes = new GroupedShape();
        private GroupedShape clipBoard = new GroupedShape();
        private bool clear = false;
        public Color Colour = Color.Black;
        public Mode Mode = Mode.Select;
        private Stack<Shape> undoStack = new Stack<Shape>();
        private Stack<Shape> redoStack = new Stack<Shape>();

        public Canvas()
            : base()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs p)
        {
            base.OnPaint(p);

            if (this.clear)
            {
                this.clear = false;
                p.Graphics.Clear(Color.White);
                return;
            }

            p.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (Shape shape in this.shapes)
            {
                if (shape is Select)
                {
                    Select select = (Select)shape;

                    using (Brush brush = new SolidBrush(select.FillColour))
                    {
                        select.Draw(p.Graphics, brush);
                    }
                }

                using (Pen pen = new Pen(shape.Colour, shape.Thickness))
                {
                    shape.Draw(p.Graphics, pen);
                }
            }
        }

        public void AddNewShape(Point position)
        {
            switch (this.Mode) {
                case Mode.Select:
                    Select select = new Select(position);
                    this.shapes.Add(select);
                    break;

                case Mode.FreeHand:
                    FreeLine freeLine = new FreeLine(position, this.Colour);
                    this.shapes.Add(freeLine);
                    // add a line here that adds each shape as something that can be undone
                    this.undoStack.Push(freeLine);
                    break;

                case Mode.Line:
                    Line line = new Line(position, this.Colour);
                    this.shapes.Add(line);
                    // add a line here that adds each shape as something that can be undone
                    this.undoStack.Push(line);
                    break;

                case Mode.Rectangle:
                    Rectangle rectangle = new Rectangle(position, this.Colour);
                    this.shapes.Add(rectangle);
                    // add a line here that adds each shape as something that can be undone
                    this.undoStack.Push(rectangle);
                    break;

                case Mode.Square:
                    Square square = new Square(position, this.Colour);
                    this.shapes.Add(square);
                    // add a line here that adds each shape as something that can be undone
                    this.undoStack.Push(square);
                    break;

                case Mode.Ellipse:
                    Ellipse ellipse = new Ellipse(position, this.Colour);
                    this.shapes.Add(ellipse);
                    // add a line here that adds each shape as something that can be undone
                    this.undoStack.Push(ellipse);
                    break;

                case Mode.Circle:
                    Circle circle = new Circle(position, this.Colour);
                    this.shapes.Add(circle);
                    // add a line here that adds each shape as something that can be undone
                    this.undoStack.Push(circle);
                    break;

                case Mode.Polygon:
                    Polygon polygon = new Polygon(position, this.Colour);
                    Line line1 = new Line(position, this.Colour);
                    polygon.addLine(line1);
                    this.shapes.Add(polygon);
                    // add a line here that adds each shape as something that can be undone
                    // undo one line of the polygon at a time
                    this.undoStack.Push(polygon);
                    break;
            }

            this.Invalidate(); // Update the canvas
        }

        public void AddToCurrentShape(Point position)
        {
            if (this.shapes.Count == 0)
                return;
            Shape shape = this.shapes.Last();

            if (shape is Select)
            {
                Select select = (Select)shape;
                select.EndPoint = position;
            }
            else if (shape is FreeLine)
            {
                FreeLine freeLine = (FreeLine)shape;
                freeLine.Points.Add(position);
            }
            else if (shape is Line)
            {
                Line line = (Line)shape;
                line.EndPoint = position;
            }
            else if (shape is Rectangle)
            {
                Rectangle rectangle = (Rectangle)shape;
                rectangle.EndPoint = position;
            }
            else if (shape is Square)
            {
                Square square = (Square)shape;
                square.EndPoint = position;
            }
            else if (shape is Ellipse)
            {
                Ellipse ellipse = (Ellipse)shape;
                ellipse.EndPoint = position;
            }
            else if (shape is Circle)
            {
                Circle circle = (Circle)shape;
                circle.EndPoint = position;
            }
            else if (shape is Polygon)
            {
                Polygon polygon = (Polygon)shape;
                polygon.getCurrentLine().EndPoint = position;
            }

            this.Invalidate(); // Update the canvas
        }

        public bool AddLineToCurrentShape(Point position)
        {
            if (this.shapes.Count == 0)
                return false;
            Shape shape = this.shapes.Last();
            bool isDrawing = true;
                
            if (shape is Polygon)
            {
                Polygon polygon = (Polygon)shape;
                
                if (Math.Abs(polygon.getStartPoint().X - position.X) < 20 && Math.Abs(polygon.getStartPoint().Y - position.Y) < 20)
                {
                    polygon.getCurrentLine().EndPoint = polygon.getStartPoint(); //close polygon
                    polygon.EndPoint = polygon.getStartPoint();
                    isDrawing = false;
                }
                else
                {
                    polygon.getCurrentLine().EndPoint = position;
                    Line line = new Line(position, this.Colour);
                    polygon.addLine(line);
                }

            }
            this.Invalidate(); //update the canvas
            return isDrawing;
        }

        public void MoveCurrentShape(Point position)
        {
            if (this.selectedShapes.Shapes.Count == 0)
            {
                return;
            }
            int xD = position.X - selectedShapes.UpperLeftPoint.X;
            int yD = position.Y - selectedShapes.UpperLeftPoint.Y;
            selectedShapes.Shift(xD, yD);
                
            this.Invalidate();
        }

        public bool SelectShapes()
        {
            if (this.shapes.Count() == 0)
            {
                return false;
            }

            Shape shape = this.shapes.Last();

            if (shape is Select)
            {
                Select select = (Select)shape;

                this.RemoveSelect();

                this.selectedShapes = select.FindContainedShapes(this.shapes.Where(x => !(x is Select)).ToList(), this.Width);
                
                if (this.selectedShapes.Shapes.Count > 0)
                {
                    this.selectedShapes.Select();
                }
            }

            this.Invalidate(); // Update the canvas

            return this.selectedShapes.Shapes.Count > 0;
        }

        public void GroupSelectedShapes()
        {
            if (this.selectedShapes.Shapes.Count < 2)
            {
                return;
            }

            foreach (Shape shape in this.selectedShapes.Shapes)
            {
                this.shapes.Remove(shape);
            }

            this.shapes.Add(this.selectedShapes);
        }

        public void UngroupSelectedShapes(Shape shape)
        {
            if (shape is GroupedShape)
            {
                GroupedShape groupedShape = (GroupedShape)shape;

                foreach (Shape subShape in groupedShape.Shapes)
                {
                    if (subShape is GroupedShape)
                    {
                        this.shapes.Remove(subShape);
                        this.UngroupSelectedShapes(subShape);
                    }
                    else
                    {
                        this.shapes.Add(subShape);
                    }
                }
            }
        }

        public void Cut()
        {
            this.clipBoard = selectedShapes;

            foreach (Shape s in clipBoard.Shapes)
            {
                this.shapes.Remove(s);
            }

            this.Invalidate();
        }

        public void Paste(Point startPoint)
        {
            if (clipBoard.Shapes.Count == 0)
                return;

            this.RemoveSelect();
            Shape newShape = this.clipBoard.Clone<Shape>();
            int xD = startPoint.X - clipBoard.UpperLeftPoint.X;
            int yD = startPoint.Y - clipBoard.UpperLeftPoint.Y;
            newShape.Shift(xD, yD);
            this.Shapes.Add(newShape);
            this.Invalidate();
        }

        public void Undo()
        {
            /* At this point, we have loaded all shapes into the stack. When we click Undo, we will be
             * sent here, where we will have to pop the top shape on the stack. Then, we have to remove 
             * that shape from the total list of shapes. We also have to put the popped value in the 
             * stack for redos for it to be readded on redo */

            Shape tempShape = this.undoStack.Pop();
            this.shapes.Remove(tempShape);
            this.redoStack.Push(tempShape);
            this.Invalidate();   
        }

        public void Redo()
        {
            Shape tempShape = this.redoStack.Pop();
            this.undoStack.Push(tempShape);
            this.shapes.Add(tempShape);
            this.Invalidate();
        }

        public void ClearCanvas()
        {
            this.clear = true;
            this.shapes.Clear();
            this.undoStack.Clear();
            this.redoStack.Clear();
            this.Invalidate();
        }

        public void RemoveSelect()
        {
            this.shapes.RemoveAll(x => x is Select);
            
            foreach (Shape shape in this.shapes)
            {
                if (shape.IsSelected)
                {
                    shape.Deselect();
                }
            }

            this.Invalidate();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
        public List<Shape> Shapes
        {
            get { return this.shapes; }
            set { this.shapes = value; }
        }

        public GroupedShape SelectedShape
        {
            get { return this.selectedShapes; }
        }

        public bool checkForUndos()
        {
            // return true if the undo stack has something in it 
            return !(this.undoStack.Count == 0);
        }

        public bool checkForRedos()
        {
            // return true if the redo stack has something in it
            return !(this.redoStack.Count == 0);
        }
    }
}
