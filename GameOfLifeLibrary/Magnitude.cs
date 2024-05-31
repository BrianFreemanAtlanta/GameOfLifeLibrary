


using System.Text;

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
    private readonly List<uint> numbers = [];
    public bool IsNegative = false;
    public Magnitude(uint number, bool isNegative = false)
    {
        this.numbers = [number];
        IsNegative = isNegative;
    }

    public Magnitude(List<uint> numbers, bool isNegative = false)
    {
        this.numbers.AddRange(numbers);
        IsNegative = isNegative;
    }

    public override bool Equals(object? obj)
    {
        if(obj is Magnitude magnitude)
        {
            if( numbers.Count != magnitude.numbers.Count) return false;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] != magnitude.numbers[i]) return false;
            }
            return true;
        }

        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        int hash = 17;
        unchecked
        {
            foreach (uint item in numbers)
            {
                hash = hash * 23 + item.GetHashCode();
            }
        }
        return hash;
    }

    public List<uint> Numbers()
    {
       return numbers;
    }

    public uint ToUint32()
    {
        if (numbers.Count > 1) { throw new OverflowException(); }
        return numbers.Last();
    }

    public override string? ToString()
    {
        StringBuilder sb = new();

        if(IsNegative) sb.Append('-');

        foreach (var number in numbers)
        {
            sb.Append(number);
            sb.Append(';');
        }
        sb.Remove(sb.Length - 1, 1);
        return sb.ToString();
    }
    public static bool? operator == (Magnitude? magnitude1, Magnitude? magnitude2) {
        if (magnitude1 is null)
        { 
            if (magnitude2 is null) return true;
            return false;
        }
        return magnitude1?.Equals(magnitude2); 
    }
    public static bool? operator != (Magnitude? magnitude1, Magnitude? magnitude2) { 
        return !(magnitude1 == magnitude2);
    }
}
