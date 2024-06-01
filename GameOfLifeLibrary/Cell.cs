using System.Drawing;

namespace GameOfLifeLibrary;

public class Cell
{
    private readonly List<Cell> _neighbors;

    public bool IsAlive {  get; set; }
    public Location Location { get; set; }
    public Point Point { get; set; }
    public Board? Board { get; set; }

    public Cell()
    {
        IsAlive = true;
        _neighbors = [];
        Location = new Location([0], [0]);
        Point = new Point();
    }
    public Cell(List<int> x, List<int> y)
    {
        Location = new Location(x, y);
        IsAlive = true;
    }
    public Cell(int  x, int y)
    {
        Point = new Point(x, y);
        IsAlive = true;
        Location = new Location([x], [y]);
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