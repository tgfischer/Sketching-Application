﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;

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
            foreach(Line line in lines){
                line.Draw(g, pen);
            }
            //g.DrawLine(pen, this.start, this.end);
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

        [XmlArrayItem(ElementName = "Line")]
        public List<Line> Lines
        {
            get { return this.lines; }
            set { this.lines = value; }
        }
    }
}
