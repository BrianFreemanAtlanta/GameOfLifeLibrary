namespace GameOfLifeLibrary;

public class Location(List<int> x, List<int> y)
{
    private readonly List<int> x = x;
    private readonly List<int> y = y;

    public List<int> Y => y;

    public List<int> X => x;
}