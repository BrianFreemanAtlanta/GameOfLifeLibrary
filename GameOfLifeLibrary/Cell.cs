namespace GameOfLifeLibrary;

public class Cell
{
    private List<Cell> _neighbors;

    public bool IsAlive {  get; set; }
    public Cell()
    {
        IsAlive = true;
        _neighbors = new List<Cell>();
    }

     public bool NextState(int numberOfNeighbors)
    {
        if (numberOfNeighbors == 3) return true;
        if (IsAlive && numberOfNeighbors == 2) return true;
        return false;
    }

    public int GetNumberOfNeighbors()
    {
        return _neighbors.Where(c=> c.IsAlive).Count();
    }

    public List<Cell> Neighbors()
    {
        return _neighbors;
    }
}