using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    public class Polygon : Shape
    {
        private Point start;
        private Point end;
        private Line currentLine;
        private List<Line> lines;
        
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
                return new Point(0, 0);
            }
        }
    }
}
