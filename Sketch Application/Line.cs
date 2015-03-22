using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    class Line : Shape
    {
        private Point start;
        private Point end;

        public Line(Point start)
        {
            this.start = start;
        }

        public void Draw()
        {

        }
    }
}
