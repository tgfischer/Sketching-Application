using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketch_Application
{
    public enum Mode
    {
        
        Select,
        Move,
        FreeHand,
        Line,
        Rectangle,
        Square,
        Ellipse,
        Circle,
        Polygon,
        Fill      // for implementing filling a closed loop on click 
    }
}
