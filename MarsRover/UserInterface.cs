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
        private const string VALID_MOVEMENT = "L|R|M";
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
                throw new ArgumentException("Plateau coordinates must be positive!");
            }
        }
 
        public void checkInputForRover(string[] input, int maxX, int maxY)
        {
            checkInputForRover(int.Parse(input[0]), int.Parse(input[1]), Convert.ToChar(input[2]), maxX, maxY);
        }

        private void checkInputForRover(int x, int y, char o, int maxX, int maxY)
        {
            if (x < ZERO || y < ZERO)
            {
                throw new ArgumentException("Position must be more than zero!");
            }
            else if (!VALID_ORIENTATION.Contains(o.ToString()))
            {
                throw new ArgumentException("Orientation must be N, E, S or W!");
            }
            else if (x > maxX || y > maxY)
            {
                throw new ArgumentException("Position given is not within Plateau dimensions!");
            }
        }

        public char[] checkInputForMovement(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Enter valid movement instructions!");
            }

            char[] movement = input.ToCharArray();

            foreach (char m in movement)
            {
                if (!VALID_MOVEMENT.Contains(m.ToString()))
                {
                    throw new ArgumentException("Movment must be either L, R or M!");
                }
            }
            return movement;
        }
    }
}
