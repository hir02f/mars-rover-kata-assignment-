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
        public Plateau Plateau { get; private set; }
        public Dictionary<Tuple<int, int>, Rover> WhereRoversAre { get; private set; }
        public Rover CurrentRover { get; private set; }

        public MissionControl()
        {
            WhereRoversAre = new Dictionary<Tuple<int, int>, Rover>();
        }
        public void SetPlateau(int x, int y)
        {
            Plateau = new Plateau(x, y);
            Console.WriteLine("(MC)Plateau Set as " + Plateau.MaxX.ToString() + " "  + Plateau.MaxY.ToString());
        }

        public void SetRovers(int x, int y, char o)
        {
            Console.WriteLine("whereroversare? " + WhereRoversAre.ContainsKey(new Tuple<int, int> (x, y)));
            if (!WhereRoversAre.ContainsKey((new Tuple<int, int>(x, y)))) 
            {
                CurrentRover = new Rover(Plateau);  // rewrite test positioning to test this code, and remove redundant code
                CurrentRover.PlaceInPosition(x, y, o);
                WhereRoversAre.Add(new Tuple<int, int>(x, y), CurrentRover);
            }
            else
            {
                throw new ArgumentException("Position has a rover already!");
            }

        }

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
