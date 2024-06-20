using GameOfLifeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace GameOfLifeLibraryTest;

[TestClass]
public class BoardTests
{
    [TestMethod]
    public void NewBoardHasNoCells()
    {
        var board = new Board();
        Assert.AreEqual(0, board.GetCells().Count);
    }
    [TestMethod]
    public void CanAddCellToBoard()
    {
        var board = new Board();
        board.Add(new Cell());
        Assert.AreEqual(1, board.GetCells().Count);
    }
    [TestMethod]
    public void CellhasReferenceToBoard()
    {
        var board = new Board();
        Cell cell = new Cell();
        board.Add(cell);
        Assert.AreEqual(board, cell.Board);
    }
    [TestMethod]
    public void CountOnlyLiveCells()
    {
        var board = new Board();
        Cell cell = new Cell() { IsAlive=false};
        board.Add(cell);
        Assert.AreEqual(0, board.GetCells().Count);
    }
    [TestMethod]
    public void BoardGetCellReturnsCell()
    {
        var cell = new Cell(5, 10);
        var board = new Board();
        board.Add(cell);
        var actual = board.GetCell(5, 10);
        Assert.AreEqual(cell, actual);
    }
    [TestMethod]
    public void BoardGetCellEmptyReturnsDeadCell()
    {
        var board = new Board();
        var cell = board.GetCell(5, 10);
        Assert.IsFalse(cell.IsAlive);
        Assert.AreEqual(5, cell.Point.X);
        Assert.AreEqual(10, cell.Point.Y);
    }
    [TestMethod]
    public void BoardGetCellEmptReturnsDeadCell()
    {
        var board = new Board();
        var cell = board.GetCell(5, 10);
        Assert.IsFalse(cell.IsAlive);
        Assert.AreEqual(5, cell.Point.X);
        Assert.AreEqual (10, cell.Point.Y);
    }
    [TestMethod]
    public void GetCellReturnAllReturnsDeadCell()
    {
        var board = new Board();
        board.Add(new Cell(5,10,false));
        var list = board.GetCells(true);
        Assert.AreEqual(1, list.Count);
    }
    [TestMethod]
    [DataRow(1, 1, 1, 2)]
    [DataRow(1, 1, 1, 0)]
    [DataRow(1, 1, 2, 0)]
    [DataRow(1, 1, 2, 1)]
    [DataRow(1, 1, 2, 2)]
    [DataRow(1, 1, 0, 0)]
    [DataRow(1, 1, 0, 1)]
    [DataRow(1, 1, 0, 2)]
    public void GetNeighborsReturnsLiveNeighbor(int cellx, int celly, int neighborx, int neighbory)
    {
        var cell1 = new Cell(cellx,celly);
        var cell2 = new Cell(neighborx, neighbory);
        var board = new Board();
        board.Add(cell1);
        board.Add(cell2);
        var neighbors1 = board.GetNeighbors(cellx, celly);
        Assert.IsTrue(neighbors1.Contains(cell2));
    }
    [TestMethod]
    public void GetNeighborsFullGets8LiveNeighbors()
    {
        var neighbors = new List<Cell>()
        {
            new(1, 2),
            new(1, 0),
            new(2, 0),
            new(2, 1),
            new(2, 2),
            new(0, 0),
            new(0, 1),
            new(0, 2),
        };
        var board = new Board();
        board.Add(new Cell(1, 1));
        foreach (var neighbor in neighbors)
        {
            board.Add(neighbor);
        }
        var actual = board.GetNeighbors(1, 1);
        CollectionAssert.AreEquivalent(neighbors, actual);
    }
    [TestMethod]
    public void GetNeighborHandlesIntXIntMax()
    {
        var neighbors = new List<Cell>()
        {
            new(int.MaxValue, 2),
            new(int.MaxValue, 0),
            new(int.MaxValue-1, 0),
            new(int.MaxValue-1, 1),
            new(int.MaxValue-1, 2),
        };
        var board = new Board();
        foreach (var neighbor in neighbors)
        {
            board.Add(neighbor);
        }
        var actual = board.GetNeighbors(int.MaxValue, 1);
        CollectionAssert.AreEquivalent(neighbors, actual);
    }
    [TestMethod]
    public void GetNeighborHandlesIntXMinMax()
    {
        var neighbors = new List<Cell>()
        {
            new(int.MinValue, 2),
            new(int.MinValue, 0),
            new(int.MinValue+1, 0),
            new(int.MinValue+1, 1),
            new(int.MinValue+1, 2),
        };
        var board = new Board();
        foreach (var neighbor in neighbors)
        {
            board.Add(neighbor);
        }
        var actual = board.GetNeighbors(int.MinValue, 1);
        CollectionAssert.AreEquivalent(neighbors, actual);
    }
    [TestMethod]
    public void SetNextStepHandles1Cell()
    {
        var board = new Board();
        var cell = new Cell(1, 1);
        board.Add(cell);
        board.SetNextStep();
        var list = board.GetCells();
        Assert.AreEqual(0, list.Count);
    }
    [TestMethod]
    public void SetNextStepHandles3Cell()
    {
        List<Cell> expected = [ 
            new Cell(0,1),
            new Cell(-1,1),
            new Cell(1,1)
        ];
        var board = new Board();
        var cell = new Cell(0, 0);
        board.Add(cell);
        var cell2 = new Cell(0, 1);
        board.Add(cell2);
        var cell3 = new Cell(0, 2);
        board.Add(cell3);
        board.SetNextStep();
        var list = board.GetCells();
//        Assert.AreEqual(1, list.Count);
        CollectionAssert.AreEquivalent(expected, list);
    }
    [TestMethod]
    public void SetNextStepHandles3CellAllLive1Birth()
    {
        List<Cell> expected = [
            new Cell(0,1),
            new Cell(0,0),
            new Cell(1,0),
            new Cell(1,1),
        ];
        var board = new Board();
        var cell = new Cell(0, 1);
        board.Add(cell);
        var cell2 = new Cell(0, 0);
        board.Add(cell2);
        var cell3 = new Cell(1, 0);
        board.Add(cell3);
        board.SetNextStep();
        var list = board.GetCells();
        CollectionAssert.AreEquivalent(expected, list);
    }
    [TestMethod]
    public void SetNextStepHandlesXMaxInt()
    {
        List<Cell> expected = [
            new Cell(int.MaxValue -1,1),
            new Cell(int.MaxValue,1),
        ];
        var board = new Board();
        var cell = new Cell(int.MaxValue, 1);
        board.Add(cell);
        var cell2 = new Cell(int.MaxValue, 0);
        board.Add(cell2);
        var cell3 = new Cell(int.MaxValue, 2);
        board.Add(cell3);
        board.SetNextStep();
        var list = board.GetCells();
        CollectionAssert.AreEquivalent(expected, list);
    }
}
