using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class UserInterface
    {
        private const string VALID_ORIENTATION = "N|E|S|W";
        private const int ZERO = 0; 

        public void checkInputForPlateau(string[] plateauInputArray, List<int> plateauCoordinates)
        {
            foreach (var coord in plateauInputArray)
            { 
                plateauCoordinates.Add(int.Parse(coord));                
            }

            if (plateauCoordinates.Count > 2)
            {
                throw new ArgumentException("Just enter two numbers followed by a space in between them!");
            }

            if (plateauCoordinates[0] < ZERO || plateauCoordinates[1] < ZERO)
            {
                throw new ArgumentException("Position must be more than zero!");
            }
        }
 
        public void checkInputForRover(string[] input)
        {
            checkInputForRover(int.Parse(input[0]), int.Parse(input[1]), Convert.ToChar(input[2]));
        }
        public void checkInputForRover(int x, int y, char o)
        {
            if (x < ZERO || y < ZERO)
            {
                throw new ArgumentException("Position must be more than zero!");
            }
            else if (!VALID_ORIENTATION.Contains(o.ToString()))
            {
                throw new ArgumentException("Orentation must be N, E, S or W!");
            }
        }
    }
}
