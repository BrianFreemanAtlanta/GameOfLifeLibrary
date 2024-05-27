﻿namespace GameOfLifeLibrary;

public class Cell
{
    private readonly List<Cell> _neighbors;

    public bool IsAlive {  get; set; }
    public Location Location { get; set; }
    public Board? Board { get; set; }

    public Cell()
    {
        IsAlive = true;
        _neighbors = [];
    }
    public Cell(List<int> x, List<int> y)
    {
        Location = new Location(x, y);
        IsAlive = true;
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