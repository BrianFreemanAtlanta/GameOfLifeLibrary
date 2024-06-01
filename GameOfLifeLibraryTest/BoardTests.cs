using GameOfLifeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    public void BoardGetCellEmptyAddsDeadCellToBoard()
    {
        var board = new Board();
        _ = board.GetCell(5, 10);
        var list = board.GetCells(true);
        Assert.AreEqual(1, list.Count);
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
    public void GetNeighborsReturnsNeighborAbove()
    {
        var cell1 = new Cell(1, 1);
        var cell2 = new Cell(1, 2);
        var board = new Board();
        board.Add(cell1);
        board.Add(cell2);
        var neighbors1 = board.GetNeighbors(1, 1);
        Assert.IsTrue(neighbors1.Contains(cell2));
    }
}
