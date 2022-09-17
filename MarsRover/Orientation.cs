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
            OrientationLookup.Add("NR", 'E');
            OrientationLookup.Add("WL", 'S');
            OrientationLookup.Add("WR", 'N');
            OrientationLookup.Add("EL", 'N');
            OrientationLookup.Add("ER", 'S');
            OrientationLookup.Add("SL", 'E');
            OrientationLookup.Add("SR", 'W');
        }

        public char GetNewOrientation(char instruction)
        {
            string lookFor = O.ToString() + instruction.ToString();

            if (OrientationLookup.ContainsKey(lookFor))
            {
                return OrientationLookup[lookFor];
            }
            else
            {
                throw new ArgumentException("Invalid orientation movement!");
            }
        }
    }
}
