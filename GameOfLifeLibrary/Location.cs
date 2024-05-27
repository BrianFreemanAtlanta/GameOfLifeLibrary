namespace GameOfLifeLibrary;

public class Location(int x, int y)
{
    private readonly int x = x;
    private readonly int y = y;

    public int Y => y;

    public int X => x;
}