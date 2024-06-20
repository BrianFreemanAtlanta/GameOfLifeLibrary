

using System.Drawing;

namespace GameOfLifeLibrary;

public class Board
{
    private readonly Dictionary<Point, Cell> cellPointDictionary;
    public Board()
    {
        cellPointDictionary = new Dictionary<Point, Cell>();
    }

    public List<Cell> GetCells(bool includeDeadCells = false)
    {
        var list = cellPointDictionary.Where(c => includeDeadCells || c.Value.IsAlive). Select(c => c.Value).ToList();
        return list;
    }

    public void Add(Cell cell)
    {
        cell.Board = this;
        cellPointDictionary[cell.Point] = cell;
    }

    public Cell GetCell(int x, int y)
    {
        var point = new Point(x, y);
        if (!cellPointDictionary.TryGetValue(point, out Cell? cell))
        {
            cell = new Cell(x, y, false);
            return cell;
        }
        return cell;
    }

    public List<Cell> GetNeighbors(int x, int y)
    {
        var neighbors = new List<Cell>
        {
            GetCell(x, y - 1),
            GetCell(x, y + 1),

            GetCell(x - 1, y - 1),
            GetCell(x - 1, y),
            GetCell(x - 1, y + 1)
        };
        if(x < int.MaxValue)
        {
            neighbors.AddRange([
                GetCell(x + 1, y - 1),
                GetCell(x + 1, y),
                GetCell(x + 1, y + 1),
                ]);
        }
        return neighbors;
    }

    public void SetNextStep()
    {
        List<Cell> deadCells = [];

        List<Cell> values = [.. cellPointDictionary.Values];
        foreach (var cell in values)
        {
            List<Cell> cells = this.GetNeighbors(cell.Point.X, cell.Point.Y);
            cell.SetNextState(cells.Where(c => c.IsAlive).Count());
            foreach (var item in cells.Where(c => !c.IsAlive))
            {

                List<Cell> neighbors = this.GetNeighbors(item.Point.X, item.Point.Y);
                item.SetNextState(neighbors.Where(c => c.IsAlive).Count());
                if (item.NextState)
                {
                    this.Add(item);
                }
            }
        }

        foreach (var cell in cellPointDictionary.Values)
            cell.IsAlive = cell.NextState;
    }
}