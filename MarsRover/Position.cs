using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Position 
    {
        public int X { get; private set; }
        public int Y { get; private set; } 
        public int O { get; private set; } // orientation
        
        public Position(int x, int y, char o) //: base(x, y)
        {
            {
                X = x;
                Y = y;
                O = o;
            }
        }
    }
}
