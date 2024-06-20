using System.Drawing;

namespace GameOfLifeLibrary;

public class Cell
{

    public bool IsAlive {  get; set; }
    public Point Point { get; set; }
    public Board? Board { get; set; }
    public bool NextState { get; set; }

    public Cell()
    {
        IsAlive = true;
        Point = new Point();
    }
    public Cell(int x, int y, bool isAlive = true)
    {
        Point = new Point(x, y);
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

    public override bool Equals(object? obj)
    {
        return obj is Cell cell &&
               IsAlive == cell.IsAlive &&
               Point.Equals(cell.Point);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IsAlive, Point);
    }

    public override string? ToString()
    {
        return $"cell ({Point}) " + (IsAlive ? "" : "Dead");
        //return base.ToString();
    }
}