using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        private const char NORTH = 'N';
        private const char SOUTH = 'S';
        private const char EAST = 'E';
        private const char WEST = 'W';
        private const char LEFT = 'L';
        private const char RIGHT = 'R';

        private const int ONE_UNIT = 1;
        public MissionControl()
        {
            WhereRoversAre = new Dictionary<Tuple<int, int>, Rover>();
        }
        public void SetPlateau(int x, int y)
        {
            Plateau = new Plateau(x, y);
        }

        public void SetRovers(int x, int y, char o)
        {
            if (!WhereRoversAre.ContainsKey((new Tuple<int, int>(x, y)))) 
            {
                CurrentRover = new Rover(Plateau);  
                CurrentRover.PlaceInPosition(x, y, o);
                WhereRoversAre.Add(new Tuple<int, int>(x, y), CurrentRover);
            }
            else
            {
                throw new ArgumentException("Position has a rover already!");
            }

        }

        private bool CheckNewPosition(int x, int y)
        {
            string hasRoverErrorMsg;
            hasRoverErrorMsg = String.Format("Position ({0}, {1}) has a rover already!", x, y);

            string outsidePlateauErrorMsg;
            outsidePlateauErrorMsg = String.Format("Rover cannot move outside Plateau area!");

            return WhereRoversAre.ContainsKey(new Tuple<int, int> (x, y)) ? throw new ArgumentException(hasRoverErrorMsg) : x > Plateau.MaxX || y > Plateau.MaxY ? throw new ArgumentException(outsidePlateauErrorMsg) : true;
        }

        public void ManageRoverMoment(char[] instructions)
        {
            foreach (char ins in instructions)
            {
                if (ins == LEFT || ins == RIGHT)
                {
                    CurrentRover.CurrentOrientation.GetNewOrientation(ins);

                }
                else
                {
                    if (CurrentRover.CurrentOrientation.O == NORTH)
                    {
                        CheckNewPosition(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y + ONE_UNIT);
                        WhereRoversAre.Remove(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y));
                        CurrentRover.CurrentPosition.SetY(true);
                        WhereRoversAre.Add(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y), CurrentRover);
                    }
                    else if (CurrentRover.CurrentOrientation.O == SOUTH)
                    {
                        CheckNewPosition(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y - ONE_UNIT);
                        WhereRoversAre.Remove(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y));
                        CurrentRover.CurrentPosition.SetY(false);
                        WhereRoversAre.Add(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y), CurrentRover);
                    }
                    else if (CurrentRover.CurrentOrientation.O == EAST)
                    {
                        CheckNewPosition(CurrentRover.CurrentPosition.X + ONE_UNIT, CurrentRover.CurrentPosition.Y);
                        WhereRoversAre.Remove(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y));
                        CurrentRover.CurrentPosition.SetX(true);
                        WhereRoversAre.Add(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y), CurrentRover);
                    }
                    else if (CurrentRover.CurrentOrientation.O == WEST)
                    {
                        CheckNewPosition(CurrentRover.CurrentPosition.X - ONE_UNIT, CurrentRover.CurrentPosition.Y);
                        WhereRoversAre.Remove(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y));
                        CurrentRover.CurrentPosition.SetX(false);
                        WhereRoversAre.Add(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y), CurrentRover);
                    }
                }
            }
        }
    }
}
