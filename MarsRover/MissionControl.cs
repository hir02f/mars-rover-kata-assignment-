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
            Console.WriteLine("(MC)Plateau Set as " + Plateau.MaxX.ToString() + " "  + Plateau.MaxY.ToString());
        }

        public void SetRovers(int x, int y, char o)
        {
            Console.WriteLine("whereroversare? " + WhereRoversAre.ContainsKey(new Tuple<int, int> (x, y)));
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

        public void ManageRoverMoment(char[] instructions) // finish this method
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
                        if (!WhereRoversAre.ContainsKey(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y + ONE_UNIT)))
                        {
                            WhereRoversAre.Remove(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y));
                            CurrentRover.CurrentPosition.SetY(true);
                            WhereRoversAre.Add(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y), CurrentRover);
                        }
                        else
                        {
                            string errorMsg;
                            errorMsg = String.Format("Position ({0}, {1}) has a rover already!", CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y + 1);
                            throw new ArgumentException(errorMsg);
                        }
                    }
                    else if (CurrentRover.CurrentOrientation.O == SOUTH)
                    {
                        if (!WhereRoversAre.ContainsKey(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y - ONE_UNIT)))
                        {
                            WhereRoversAre.Remove(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y));
                            CurrentRover.CurrentPosition.SetY(false);
                            WhereRoversAre.Add(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y), CurrentRover);
                        }
                        else
                        {
                            string errorMsg;
                            errorMsg = String.Format("Position ({0}, {1}) has a rover already!", CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y - 1);
                            throw new ArgumentException(errorMsg);
                        }
                    }
                    else if (CurrentRover.CurrentOrientation.O == EAST)
                    {
                        if (!WhereRoversAre.ContainsKey(new Tuple<int, int>(CurrentRover.CurrentPosition.X + ONE_UNIT, CurrentRover.CurrentPosition.Y)))
                        {
                            WhereRoversAre.Remove(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y));
                            CurrentRover.CurrentPosition.SetX(true);
                            WhereRoversAre.Add(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y), CurrentRover);
                        }
                        else
                        {
                            string errorMsg;
                            errorMsg = String.Format("Position ({0}, {1}) has a rover already!", CurrentRover.CurrentPosition.X + ONE_UNIT, CurrentRover.CurrentPosition.Y);
                            throw new ArgumentException(errorMsg);
                        }
                    }
                    else if (CurrentRover.CurrentOrientation.O == WEST)
                    {
                        if (!WhereRoversAre.ContainsKey(new Tuple<int, int>(CurrentRover.CurrentPosition.X - ONE_UNIT, CurrentRover.CurrentPosition.Y)))
                        {
                            WhereRoversAre.Remove(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y));
                            CurrentRover.CurrentPosition.SetX(false);
                            WhereRoversAre.Add(new Tuple<int, int>(CurrentRover.CurrentPosition.X, CurrentRover.CurrentPosition.Y), CurrentRover);
                        }
                        else
                        {
                            string errorMsg;
                            errorMsg = String.Format("Position ({0}, {1}) has a rover already!", CurrentRover.CurrentPosition.X - ONE_UNIT, CurrentRover.CurrentPosition.Y);
                            throw new ArgumentException(errorMsg);
                        }
                    }
                }
            }
        }
    }
}
