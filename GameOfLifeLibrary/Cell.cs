using System.Drawing;

namespace GameOfLifeLibrary;

public class Cell
{

    public bool IsAlive {  get; set; }
    public Location Location { get; set; }
    public Point Point { get; set; }
    public Board? Board { get; set; }
    public bool NextState { get; set; }

    public Cell()
    {
        IsAlive = true;
        Location = new Location([0], [0]);
        Point = new Point();
    }
    public Cell(List<int> x, List<int> y)
    {
        Location = new Location(x, y);
        IsAlive = true;
    }
    public Cell(int x, int y, bool isAlive = false)
    {
        Point = new Point(x, y);
        Location = new Location([x], [y]);
        IsAlive = isAlive;
    }

    public bool GetNextState(int numberOfNeighbors)
    {
        if (numberOfNeighbors == 3) return true;
        if (IsAlive && numberOfNeighbors == 2) return true;
        return false;
    }

    public void SetNextState(int numberOfNeighbors)
    {
        NextState = GetNextState(numberOfNeighbors);
    }
}