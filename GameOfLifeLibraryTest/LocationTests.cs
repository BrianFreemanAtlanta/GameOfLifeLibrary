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
}
