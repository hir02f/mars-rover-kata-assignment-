namespace MarsRover
{
    public class Position 
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private const int ONE_UNIT = 1;
        
        public Position(int x, int y)
        {
            {
                X = x;
                Y = y; 
            }
        }

        public void SetY(bool input)
        {
            Y = input ? Y + ONE_UNIT : Y - ONE_UNIT;
        }

        public void SetX(bool input)
        {
            X = input ? X + ONE_UNIT : X - ONE_UNIT;
        }
    }
}

