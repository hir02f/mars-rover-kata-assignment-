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
    }
}
