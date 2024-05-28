
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
        CollectionAssert.AreEqual(numbers, magnitude.Numbers());
    }
    [TestMethod]
    public void SingleDigitReturnsSingleNumber()
    {
        var magnitude = new Magnitude(5);
        CollectionAssert.AreEquivalent(new List<int>() { 5 }, magnitude.Numbers());
    }
}
