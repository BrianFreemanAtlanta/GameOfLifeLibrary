
using GameOfLifeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeLibraryTest;
[TestClass]
public class MagnitudeTests
{
    [TestMethod]
    public void CreateMagnitudeWithSingleNumber()
    {
        var magnitude = new Magnitude(5);
        Assert.AreEqual(5, magnitude.ToInt());
    }
    [TestMethod]
    public void CreateMagnitudeWithTwoNumbers()
    {
        var numbers = new List<int>() { 1, 5 };
        var magnitude = new Magnitude(numbers);
        Assert.AreEqual(numbers, magnitude.Numbers());

    }
}
