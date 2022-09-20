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

        public bool checkInputForPlateau(string[] plateauInputArray, List<int> plateauCoordinates)
        {
            foreach (var coord in plateauInputArray)
            {
                try
                {
                    plateauCoordinates.Add(int.Parse(coord));
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }

            if (plateauCoordinates.Count > 2)
            {
                Console.WriteLine("Just enter two numbers followed by a space in between them!");
                return false;
            }

            if (plateauCoordinates[0] < ZERO || plateauCoordinates[1] < ZERO)
            {
                throw new ArgumentException("Position must be more than zero!");
            }
            else
            {
                return true;
            }
        }

        public bool checkInputForRover(int x, int y, char o)
        {
            if (x < ZERO || y < ZERO)
            {
                throw new ArgumentException("Position must be more than zero!");
            }
            else if (!VALID_ORIENTATION.Contains(o.ToString()))
            {
                throw new ArgumentException("Orentation must be N, E, S or W!");
            }
            else
            {
                return true;
            }
        }
    }
}
