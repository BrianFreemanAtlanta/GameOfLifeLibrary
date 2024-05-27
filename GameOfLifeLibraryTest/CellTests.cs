using GameOfLifeLibrary;

namespace GameOfLifeLibraryTest
{
    [TestClass]
    public class CellTests
    {
        [DataTestMethod]
        [DataRow(0, false)]
        [DataRow(1, false)]
        [DataRow(3, true)]
        public void CellNeighbors(int numberOfNeighbors, bool expected)
        {
            var cell = new Cell();
            Assert.AreEqual(expected, cell.NextState(numberOfNeighbors), $"Cell with {numberOfNeighbors} neighbors should return {expected}");
        }
        [TestMethod]
        public void NewCellIsAlive()
        {
            var cell = new Cell();
            Assert.IsTrue(cell.IsAlive);
        }
    }
}