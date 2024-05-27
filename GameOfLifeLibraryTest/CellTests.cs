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
        [TestMethod]
        public void CellWith0NeighborsDies()
        {
            var cell = new Cell();
            Assert.IsFalse(cell.NextState(0));
        }
        [TestMethod]
        public void CellWith1NeighborsDies()
        {
            var cell = new Cell();
            Assert.IsFalse(cell.NextState(1));
        }
        [TestMethod]
        public void NewCellIsAlive()
        {
            var cell = new Cell();
            Assert.IsTrue(cell.IsAlive);
        }
    }
}