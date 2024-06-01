﻿using GameOfLifeLibrary;
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
            new Cell(1, 2),
            new Cell(1, 0),
            new Cell(2, 0),
            new Cell(2, 1),
            new Cell(2, 2),
            new Cell(0, 0),
            new Cell(0, 1),
            new Cell(0, 2),
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
}
