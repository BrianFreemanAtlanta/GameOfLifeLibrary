namespace GameOfLifeLibrary;

public class Location(List<int> x, int y)
{
    private readonly List<int> x = x;
    private readonly int y = y;

    public int Y => y;

    public List<int> X => x;
}