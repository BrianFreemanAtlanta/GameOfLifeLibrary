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
        Assert.AreEqual(expected, cell.NextState(numberOfNeighbors), $"Cell with {numberOfNeighbors} neighbors should return {expected}");
    }
    [TestMethod]
    public void DeadCell2NeighborsStaysDead()
    {
        var cell = new Cell() { IsAlive = false };
        Assert.AreEqual(false, cell.NextState(2));
    }
    [TestMethod]
    public void NewCellIsAlive()
    {
        var cell = new Cell();
        Assert.IsTrue(cell.IsAlive);
    }
    [TestMethod]
    public void NewCellHasNeighborCount0()
    {
        var cell = new Cell();
        Assert.AreEqual(0, cell.GetNumberOfNeighbors());
    }
    [TestMethod]
    public void CellWith1NeighborHasCount1()
    {
        var cell = new Cell();
        cell.Neighbors().Add(new Cell());
        cell.GetNumberOfNeighbors();
        Assert.AreEqual(1, cell.GetNumberOfNeighbors());
    }
    [TestMethod]
    public void CellOnlyCountsLiveNeighbors()
    {
        var cell = new Cell();
        cell.Neighbors().Add(new Cell() { IsAlive=false});
        cell.GetNumberOfNeighbors();
        Assert.AreEqual(0, cell.GetNumberOfNeighbors());
    }
    [TestMethod]
    public void CreateCellAtLocation()
    {
        var x = new List<int>() { 0 };
        var y = new List<int>() { 0 };
        var cell = new Cell(x,y);
        Assert.AreEqual(x, cell.Location.X);
    }
}