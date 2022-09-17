using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover
    {
        public Position CurrentPosition { get; private set; }
        public Plateau Plateau { get; private set; }
        public Orientation CurrentOrientation { get; private set; }    

        private const string VALID_ORIENTATION = "N|E|S|W";

        public Rover(Plateau plateau)
        {
            Plateau = plateau;
        }

        public void PlaceInPosition(int x, int y, char o)
        {        
            if (x < 0 || y < 0)
            {
                throw new ArgumentException("Position must be more than zero!");
            }
            else if (!VALID_ORIENTATION.Contains(o.ToString()))
            {
                throw new ArgumentException("Orentation must be N, E, S or W!");
            }
            else if (x > Plateau.MaxX || y > Plateau.MaxY)
            {
                throw new ArgumentException("Position is bigger than Plateau dimensions!");
            }
            else
            {
                if (Plateau.PositionIsAvailable(x, y))
                {
                    CurrentPosition = new Position(x, y);
                    CurrentOrientation = new Orientation(o);
                    Plateau.UpdateGrid(x, y);
                }
                else
                {
                    throw new ArgumentException("Position has a rover already!");
                }
            }
        }

    }
}
