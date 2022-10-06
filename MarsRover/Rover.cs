using MarsRover.Configuration;

namespace MarsRover
{
    public class Rover : IMove
    {
        public Position CurrentPosition { get; private set; }
        public Plateau Plateau { get; private set; }
        public Orientation CurrentOrientation { get; private set; }    

        public void PlaceInPosition(int x, int y, char o)
        {
            CurrentPosition = new Position(x, y);
            CurrentOrientation = new Orientation(o);
        }

        public void MoveToNewPosition(bool isAddition)
        {
            if (CurrentOrientation.O == MissionControlDefinitions.NORTH || CurrentOrientation.O == MissionControlDefinitions.SOUTH)
            {
                CurrentPosition.SetY(isAddition);
            }
            else if (CurrentOrientation.O == MissionControlDefinitions.EAST || CurrentOrientation.O == MissionControlDefinitions.WEST)
            {
                CurrentPosition.SetX(isAddition);
            }
        }
    }
}
