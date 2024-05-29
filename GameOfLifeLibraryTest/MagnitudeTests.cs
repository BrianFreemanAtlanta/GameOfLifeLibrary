
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
        Assert.AreEqual((uint)5, magnitude.ToUint32());
    }
    [TestMethod]
    public void CreateMagnitudeWithTwoNumbers()
    {
        var numbers = new List<uint>() { 1, 5 };
        var magnitude = new Magnitude(numbers);
        CollectionAssert.AreEqual(numbers, magnitude.Numbers());
    }
    [TestMethod]
    public void SingleDigitReturnsSingleNumber()
    {
        var magnitude = new Magnitude(5);
        CollectionAssert.AreEquivalent(new List<uint>() { 5 }, magnitude.Numbers());
    }
    [TestMethod]
    public void TwoNumbersToIntegerThrowsError()
    {
        var numbers = new List<uint>() { 1, 5 };
        var magnitude = new Magnitude(numbers);
        Assert.ThrowsException<OverflowException>(() => magnitude.ToUint32());
    }
    [TestMethod]
    public void CreateUintMaxNumber()
    {
        var magnitude = new Magnitude(uint.MaxValue);
        Assert.AreEqual(uint.MaxValue, magnitude.ToUint32());
    }
    [TestMethod]
    public void ToStringSingleDigit()
    {
        var magnitude = new Magnitude(5);
        Assert.AreEqual("5", magnitude.ToString());
    }
    [TestMethod]
    public void ToStringTwoDigit()
    {
        var numbers = new List<uint>() { 1, 5 };
        var magnitude = new Magnitude(numbers);
        Assert.AreEqual("1;5", magnitude.ToString());
    }
}
