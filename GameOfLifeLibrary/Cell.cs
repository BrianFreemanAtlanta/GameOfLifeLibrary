

namespace GameOfLifeLibrary
{
    public class Cell
    {
        public bool IsAlive {  get; set; }
        public Cell()
        {
            IsAlive = true;
        }

         public bool NextState(int numberOfNeighbors)
        {
            if(numberOfNeighbors < 2) { return false; }
            return true;
        }
    }
}