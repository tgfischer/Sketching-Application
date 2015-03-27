using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    [Serializable]
    public class Polygon : Shape
    {
        private Point start;
        private Point end;
        private Line currentLine;
        public List<Line> lines;

        
        private Polygon() { }

        public Polygon(Point start, Color colour)
            : base(colour)
        {
            this.lines = new List<Line>();
            this.start = start;
            this.end = start;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            foreach (Line line in this.lines) {
                line.Draw(g, pen);
            }
        }

        public override void Shift(int x, int y)
        {
            foreach (Line line in this.Lines)
            {
                line.Shift(x, y);
            }
        }

        public void addLine(Line line)
        {
            currentLine = line;
            lines.Add(currentLine);
        }
       
        public Line getCurrentLine()
        {
            return currentLine;
        }

        public Point getStartPoint()
        {
            return start;
        }

        public Point getEndPoint()
        {
            return end;
        }

        public virtual Point EndPoint
        {
            set { this.end = value; }
           
        }

        public List<Line> Lines
        {
            get { return this.lines; }
            set { this.lines = value; }
        }

        public override Point UpperLeftPoint
        {
            get
            {
                int x = Int32.MaxValue;
                int y = Int32.MaxValue;

                for (int i = 0; i < this.lines.Count(); i++)
                {
                    if (this.lines.ElementAt(i).EndPoint.X < x)
                        x = this.lines.ElementAt(i).EndPoint.X;
                    if (this.lines.ElementAt(i).EndPoint.Y < y)
                        y = this.lines.ElementAt(i).EndPoint.Y;
                    if (this.lines.ElementAt(i).StartPoint.X < x)
                        x = this.lines.ElementAt(i).StartPoint.X;
                    if (this.lines.ElementAt(i).StartPoint.Y < y)
                        y = this.lines.ElementAt(i).StartPoint.Y;
                }

                return new Point(x, y);
            }
        }
    }
}
