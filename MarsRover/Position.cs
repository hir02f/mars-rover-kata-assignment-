using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Position : Plateau 
    {
        public Position(int x, int y) : base(x, y)
        {

        }

        private bool _isEmpty; // ie no Rover at that coordinate
        public bool IsEmpty 
        { 
            get { return _isEmpty; } 
            set { _isEmpty = true; } 
        }
        
    }
}
