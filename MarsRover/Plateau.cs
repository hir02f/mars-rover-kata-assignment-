namespace MarsRover
{
    public class Plateau
    {
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }

        public List<int[]> GridOfRovers = new List<int[]>();

        public Plateau(int x, int y)
        {
            MaxX = x;
            MaxY = y;
        }
    }
}
