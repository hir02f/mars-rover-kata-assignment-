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

        private Dictionary<string, char> OrientationLookup = new Dictionary<string, char>();
 
        public Orientation(char o)
        {
            O = o;

            OrientationLookup.Add("NL", 'W');
        }

        public char GetNewOrientation(char instruction)
        {
            string lookFor = O.ToString() + instruction.ToString();
            return OrientationLookup[lookFor];         
        }
    }
}
