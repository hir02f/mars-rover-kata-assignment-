using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Orientation
    {
        public char O { get; private set; }

        private Dictionary<string, char> OrientationLookup = new Dictionary<string, char>() 
        {
            { "NL", 'W' },
            { "NR", 'E' },
            { "WL", 'S' },
            { "WR", 'N' },
            { "EL", 'N' },
            { "ER", 'S' },
            { "SL", 'E' },
            { "SR", 'W' }
        };
 
        public Orientation(char orientation)
        {
            O = orientation;
        }

        public void GetNewOrientation(char instruction)
        {
            string lookFor = O.ToString() + instruction.ToString();
            O = OrientationLookup.ContainsKey(lookFor) ? OrientationLookup[lookFor] : throw new ArgumentException("Invalid orientation movement!"); 
        }
    }
}
