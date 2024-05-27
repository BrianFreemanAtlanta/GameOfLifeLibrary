using GameOfLifeLibrary;

namespace GameOfLifeLibraryTest;

[TestClass]
public class LocationTests
{
    [TestMethod]
    public void CanCreateLocation()
    {
        var location = new Location(0, 0);
        Assert.IsNotNull(location);
        Assert.AreEqual(0, location.X);
        Assert.AreEqual(0, location.Y);
    }
    [TestMethod]
    public void CreateLocationAtCoordinate()
    {
        var location = new Location(5, 10);
        Assert.IsNotNull(location);
        Assert.AreEqual(5, location.X);
        Assert.AreEqual(10, location.Y);
    }
}
