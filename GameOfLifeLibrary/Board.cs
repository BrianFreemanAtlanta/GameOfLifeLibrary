
namespace GameOfLifeLibrary;

public class Board
{
    private List<Cell> cells;

    public Board()
    {
        cells = new List<Cell>();
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
        cells.Add(cell);
    }
}