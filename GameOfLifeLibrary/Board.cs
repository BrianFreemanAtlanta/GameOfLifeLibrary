

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
        if (cellPointDictionary.TryGetValue(point, out Cell? cell))
        {
            return cell;
        }
        cell = new Cell(x, y, false);
        cellPointDictionary[cell.Point] = cell;
        return cell;
    }

    public List<Cell> GetNeighbors(int x, int y)
    {
        var neighbors = new List<Cell>
        {
            GetCell(x, y - 1),
            GetCell(x, y + 1),
            GetCell(x + 1, y - 1),
            GetCell(x + 1, y),
            GetCell(x + 1, y + 1),
            GetCell(x - 1, y - 1),
            GetCell(x - 1, y),
            GetCell(x - 1, y + 1)
        };
        return neighbors;
    }
}