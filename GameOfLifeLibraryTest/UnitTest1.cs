using GameOfLifeLibrary;

namespace GameOfLifeLibraryTest
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void CellWith3NeighborsWillLive()
        {
            var cell = new Cell();
            Assert.IsTrue(cell.NextState(3));
        }
    }
}