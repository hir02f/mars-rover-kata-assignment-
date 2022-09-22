﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover : IMove
    {
        public Position CurrentPosition { get; private set; }
        public Plateau Plateau { get; private set; }
        public Orientation CurrentOrientation { get; private set; }    

        private const char NORTH = 'N';
        private const char SOUTH = 'S';
        private const char EAST = 'E';
        private const char WEST = 'W';
        private const int ONE_UNIT = 1;

        public Rover(Plateau plateau)
        {
            Plateau = plateau;
        }

        public void PlaceInPosition(int x, int y, char o)
        {
            CurrentPosition = new Position(x, y);
            CurrentOrientation = new Orientation(o);
        }

        public void MoveToNewPosition(bool maths)
        {
            if (CurrentOrientation.O == NORTH || CurrentOrientation.O == SOUTH)
            {
                CurrentPosition.SetY(maths);
            }
            else if (CurrentOrientation.O == EAST || CurrentOrientation.O == WEST)
            {
                CurrentPosition.SetX(maths);
            }

        }

        public void MoveToNewPosition()  // split this up, use WhereRoversAre rather than addtogrid jasmine
        {
            if (CurrentOrientation.O == NORTH)
            {
                if (Plateau.PositionIsAvailable(CurrentPosition.X, CurrentPosition.Y + ONE_UNIT))
                {
                    Plateau.RemoveFromGrid(CurrentPosition.X, CurrentPosition.Y);
                    CurrentPosition.SetY(true);
                    Plateau.AddToGrid(CurrentPosition.X, CurrentPosition.Y);
                }
                else
                {
                    string errorMsg;
                    errorMsg = String.Format("Position ({0}, {1}) has a rover already!", CurrentPosition.X, CurrentPosition.Y + 1);
                    throw new ArgumentException(errorMsg);
                }
            }
            else if (CurrentOrientation.O == SOUTH)
            {
                if (Plateau.PositionIsAvailable(CurrentPosition.X, CurrentPosition.Y - ONE_UNIT))
                {
                    Plateau.RemoveFromGrid(CurrentPosition.X, CurrentPosition.Y);
                    CurrentPosition.SetY(false);
                    Plateau.AddToGrid(CurrentPosition.X, CurrentPosition.Y);
                }
            }
            else if (CurrentOrientation.O == EAST)
            {
                if (Plateau.PositionIsAvailable(CurrentPosition.X + ONE_UNIT, CurrentPosition.Y))
                {
                    Plateau.RemoveFromGrid(CurrentPosition.X, CurrentPosition.Y);
                    CurrentPosition.SetX(true);
                    Plateau.AddToGrid(CurrentPosition.X, CurrentPosition.Y);
                }
            }
            else if (CurrentOrientation.O == WEST)
            {
                if (Plateau.PositionIsAvailable(CurrentPosition.X - ONE_UNIT, CurrentPosition.Y))
                {
                    Plateau.RemoveFromGrid(CurrentPosition.X, CurrentPosition.Y);
                    CurrentPosition.SetX(false);
                    Plateau.AddToGrid(CurrentPosition.X, CurrentPosition.Y);
                }
            }
        }
    }
}
