using GameOfLifeLibrary;

namespace GameOfLifeLibraryTest;

[TestClass]
public class LocationTests
{
    [TestMethod]
    public void CanCreateLocation()
    {
        List<int> x = new List<int>() { 0 };
        List<int> y = new List<int>() { 0 };
        var location = new Location(x, y);
        Assert.IsNotNull(location);
        Assert.AreEqual(x, location.X);
        Assert.AreEqual(y, location.Y);
    }
    [TestMethod]
    public void CreateLocationAtCoordinate()
    {
        List<int> x = new List<int> { 5 };
        List<int> y = new List<int> { 10 };
        var location = new Location(x, y);
        Assert.IsNotNull(location);
        Assert.AreEqual(x, location.X);
        Assert.AreEqual(y, location.Y);
    }
    [TestMethod]
    public void CreateLocationAtCoordinateWithXPastIntMax()
    {
        List<int> x = new List<int> { int.MaxValue, 5 };
        List<int> y = new List<int> { 10 };
        var location = new Location(x, y);
        Assert.IsNotNull(location);
        Assert.AreEqual(x, location.X);
        Assert.AreEqual(y, location.Y);
    }
    [TestMethod]
    public void CreateLocationAtCoordinateWithYPastIntMax()
    {
        List<int> x = new List<int> { int.MaxValue, 5 };
        List<int> y = new List<int>() { int.MaxValue, 10 };
        var location = new Location(x, y);
        Assert.IsNotNull(location);
        Assert.AreEqual(x, location.X);
        Assert.AreEqual(y, location.Y);
    }
}
