using GameOfLifeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeLibraryTest;

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
        Assert.AreEqual(expected, cell.GetNextState(numberOfNeighbors), $"Cell with {numberOfNeighbors} neighbors should return {expected}");
    }
    [TestMethod]
    public void DeadCell2NeighborsStaysDead()
    {
        var cell = new Cell() { IsAlive = false };
        Assert.AreEqual(false, cell.GetNextState(2));
    }
    [TestMethod]
    public void NewCellIsAlive()
    {
        var cell = new Cell();
        Assert.IsTrue(cell.IsAlive);
    }

    [TestMethod]
    public void CreateCellAtPoint()
    {
        var cell = new Cell(10, 20);
        Assert.AreEqual(10, cell.Point.X);
        Assert.AreEqual (20, cell.Point.Y);
        Assert.IsTrue(cell.IsAlive);
    }
    [TestMethod]
    public void CreateDeadCellAtPoint()
    {
        var cell = new Cell(15, 20, false);
        Assert.IsFalse(cell.IsAlive);
    }
    [TestMethod]
    public void SetPendingState()
    {

    }
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
    public void SetNextState(int numberOfNeighbors, bool expected)
    {
        var cell = new Cell();
        cell.SetNextState(numberOfNeighbors);
        Assert.AreEqual(expected, cell.NextState , $"Cell with {numberOfNeighbors} neighbors should return {expected}");
    }
}