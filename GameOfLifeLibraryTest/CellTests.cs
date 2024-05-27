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
        public void NewCellIsAlive()
        {
            var cell = new Cell();
            Assert.IsTrue(cell.IsAlive());
        }
    }
}