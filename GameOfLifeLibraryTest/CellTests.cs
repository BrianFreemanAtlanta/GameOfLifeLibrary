using GameOfLifeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeLibraryTest
{
    [TestClass]
    public class CellTests
    {
        [DataTestMethod]
        [DataRow(0, false)]
        [DataRow(1, false)]
        [DataRow(2, true)]
        [DataRow(3, true)]
        [DataRow(4, false)]
        [DataRow(5, false)]
        [DataRow(6, false)]
        [DataRow(7, false)]
        [DataRow(8, false)]
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