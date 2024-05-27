namespace GameOfLifeLibrary;

public class Board
{
    private List<Cell> cells;

    public Board()
    {
        cells = new List<Cell>();
    }

    public List<Cell> Cells { get => cells; set => cells = value; }
}