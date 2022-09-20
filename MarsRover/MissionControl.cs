using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class MissionControl
    {
        public Plateau testPlateau { get; private set; }

        public List<Rover> Rovers { get; private set; }

        /*  public Position _position { get; private set; }

          public MissionControl(Plateau plateau, Position position)
          {
              _plateau = plateau;
              _position = position;
          }

          */


        public void SetPlateau(int x, int y)
        {

            testPlateau = new Plateau(x, y);
            Console.WriteLine("Plateau Set as " + testPlateau.MaxX.ToString() + " "  + testPlateau.MaxY.ToString());

        }

        public void SetRovers(int x, int y, char o)
        {
            Rover testRover = new Rover(testPlateau);
            testRover.PlaceInPosition(x, y, o);

           /* if (L or R)
            {
              testRover.CurrentOrientation.GetNewOrientation('L');
            }
            else 
            {
                testRover.MoveToNewPosition();
            }*/

        }
    }
}
