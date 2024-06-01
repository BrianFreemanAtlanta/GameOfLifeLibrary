

using System.Drawing;

namespace GameOfLifeLibrary;

public class Board
{
    private List<Cell> cells;
    private Dictionary<Point, Cell> cellPointDictionary;
    public Board()
    {
        cells = new List<Cell>();
        cellPointDictionary = new Dictionary<Point, Cell>();
    }

    public List<Cell> Cells
    {
        get
        {
            return cells.Where(c => c.IsAlive).ToList();
        }
        set => cells = value;
    }

    public void Add(Cell cell)
    {
        cell.Board = this;
        cells.Add(cell);
        cellPointDictionary[cell.Point] = cell;
    }

    public Cell GetCell(int x, int y)
    {
        //return cellPointDictionary[new Point(x, y)];
        var point = new Point(x, y);
        if (cellPointDictionary.TryGetValue(point, out Cell? cell))
        {
            return cell;
        }
        cell = new Cell(x, y, false);
        //cells.Add(cell);
        //cellPointDictionary[cell.Point] = cell;
        return cell;
    }
}