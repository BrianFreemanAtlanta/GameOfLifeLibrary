


namespace GameOfLifeLibrary;

/// <summary>
/// This will be the magnitude for the cell location
/// represented as a list of integers and a isNegative property
/// For compatibility with javascript and serialize we'll use UInt32
/// Javascript max safe number is 2^53 = 9,007,199,254,740,991
/// This list will be akin to a base UInt number so that
/// UInt.MaxValue + 1 = {1,0}
/// {UInt.MaxValue,UInt.MaxValue} + 1 = {1,0,0}
/// Has unique rules for ==, Equals, ++, --, hash
/// May need division/multiply rules for zoom in/out but will see
/// </summary>
public class Magnitude
{
    private List<int> numbers;

    public Magnitude(int number)
    {
        this.numbers = [number];
    }

    public Magnitude(List<int> numbers)
    {
        this.numbers = numbers;
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public List<int> Numbers()
    {
       return numbers;
    }

    public int ToInt()
    {
        return numbers.Last();
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}
