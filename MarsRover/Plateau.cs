using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Plateau
    {
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }

        public Plateau(int x, int y)
        {
            MaxX = x;
            MaxY = y;
        }         
    }
}
