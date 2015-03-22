using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketch_Application
{
    interface Shape
    {
        void Draw(Graphics g, Pen pen);

        //public void Add(Shape shape);

        //public void Remove(Shape shape);

        //public Shape GetChild(Shape shape);
    }
}
