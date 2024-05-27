

namespace GameOfLifeLibrary
{
    public class Cell
    {
        public Cell()
        {
        }

        public bool IsAlive()
        {
            return true;
        }

        public bool NextState(int numberOfNeighbors)
        {
            if(numberOfNeighbors < 2) { return false; }
            return true;
        }
    }
}