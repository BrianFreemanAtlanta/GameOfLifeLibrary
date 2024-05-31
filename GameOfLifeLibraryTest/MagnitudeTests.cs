
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
    [TestMethod]
    public void MagnitudeIsSeparateFromList()
    {
        var numbers = new List<uint>() { 1, 5 };
        var expected = new List<uint>() { 1, 5 };
        var magnitude = new Magnitude(numbers);
        numbers.Add(100);
        CollectionAssert.AreEqual(expected, magnitude.Numbers());
    }
    [TestMethod]
    public void EqualsWithSameOneNumberIsTrue()
    {
        var magnitude1 = new Magnitude(5);
        var magnitude2 = new Magnitude(5);
        Assert.IsTrue(magnitude1.Equals(magnitude2));
    }
    [TestMethod]
    public void DoubleEqualsWithSameOneNumberIsTrue()
    {
        var magnitude1 = new Magnitude(5);
        var magnitude2 = new Magnitude(5);
        Assert.IsTrue(magnitude1 == magnitude2);
    }
    [TestMethod]
    public void EqualsObjectToNullIsFalse()
    {
        var magnitude1 = new Magnitude(5);
        Assert.IsFalse(magnitude1.Equals(null));
    }
    [TestMethod]
    public void DoubleEqualsObjectToNullIsFalse()
    {
        Magnitude? magnitude1 = new Magnitude(5);
        Assert.IsFalse(magnitude1 == null);
    }    
    [TestMethod]
    public void DoubleEqualsNullToNullIsTrue()
    {
        Magnitude? magnitude1 = null;
        Assert.IsTrue(magnitude1 == null);
    }
    [TestMethod]
    public void DoubleEqualsNullToObjectIsFalse()
    {
        Magnitude? magnitude1 = null;
        var magnitude2 = new Magnitude(5);
        Assert.IsFalse(magnitude1 == magnitude2);
    }
    [TestMethod]
    public void NotEqualsSameMagnitudeIsFalse()
    {
        var magnitude1 = new Magnitude(5);
        var magnitude2 = new Magnitude(5);
        Assert.IsFalse(magnitude1 != magnitude2);
    }
    [TestMethod]
    public void NotEqualsDiffMagnitudeIsTrue()
    {
        var mag1 = new Magnitude(5);
        var mag2 = new Magnitude(10);
        Assert.IsTrue(mag1 != mag2);
    }
    [TestMethod]
    public void NotEqualsNullToObjectIsTrue()
    {
        Magnitude? mag1 = null;
        var mag2 = new Magnitude(5);
        Assert.IsTrue(mag1 != mag2);
    }
    [TestMethod]
    public void NotEqualsObjectToNullIsTrue()
    {
        var mag1 = new Magnitude(5);
        Magnitude? mag2 = null;
        Assert.IsTrue(mag1 != mag2);
    }
    [TestMethod]
    public void EqualsWithDifferentSingleNumbersIsFalse()
    {
        var magnitude1 = new Magnitude(5);
        var magnitude2 = new Magnitude(6);
        Assert.IsFalse(magnitude1.Equals(magnitude2));
    }
    [TestMethod]
    public void EqualsWithDifferentLengthNumbersIsFalse()
    {
        var magnitude1 = new Magnitude(5);
        var magnitude2 = new Magnitude([1,5]);
        Assert.IsFalse(magnitude1.Equals(magnitude2));
    }
    [TestMethod]
    public void EqualsWithDifferentFirstNumbersIsFalse()
    {
        var magnitude1 = new Magnitude([2,5]);
        var magnitude2 = new Magnitude([1, 5]);
        Assert.IsFalse(magnitude1.Equals(magnitude2));
    }
    [TestMethod]
    public void EqualsSameMultiDigitsIsTrue()
    {
        var magnitude1 = new Magnitude([3,2,5]);
        var magnitude2 = new Magnitude([3,2,5]);
        Assert.IsTrue(magnitude1.Equals(magnitude2));
    }
    [TestMethod]
    public void CreateNegativeUInt()
    {
        var magnitude = new Magnitude(5, true);
        Assert.IsTrue(magnitude.IsNegative);
        Assert.AreEqual((uint)5, magnitude.ToUint32());
    }
}
