
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
}
