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
        
        public Position(int x, int y)
        {
            {
                X = x;
                Y = y; 
            }
        }

        public void SetY(bool input)
        {
            Y = input ? Y + 1 : Y - 1;
        }

        public void SetX(bool input)
        {
            X = input ? X + 1 : X - 1;
        }
    }
}

