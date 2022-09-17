using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void UpdateGrid(int x, int y)
        {
            GridOfRovers.Add(new int[] { x, y });
        }

        public bool PositionIsAvailable(int x, int y)
        {
            return !GridOfRovers.Any(p => p.SequenceEqual(new int[] { x, y }));
        }
    }
}
