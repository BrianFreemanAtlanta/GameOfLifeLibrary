using GameOfLifeLibrary;

namespace GameOfLifeLibraryTest;

[TestClass]
public class LocationTests
{
    [TestMethod]
    public void CanCreateLocation()
    {
        List<int> x = new List<int>() { 0 };
        var location = new Location(x, 0);
        Assert.IsNotNull(location);
        Assert.AreEqual(x, location.X);
        Assert.AreEqual(0, location.Y);
    }
    [TestMethod]
    public void CreateLocationAtCoordinate()
    {
        List<int> x = new List<int> { 5 };
        var location = new Location(x, 10);
        Assert.IsNotNull(location);
        Assert.AreEqual(x, location.X);
        Assert.AreEqual(10, location.Y);
    }
    [TestMethod]
    public void CreateLocationAtCoordinateWithXPastIntMax()
    {
        List<int> x1 = new List<int> { int.MaxValue, 5 };
        var location = new Location(x1, 10);
        Assert.IsNotNull(location);
        Assert.AreEqual(x1, location.X);
        Assert.AreEqual(10, location.Y);
    }
}
