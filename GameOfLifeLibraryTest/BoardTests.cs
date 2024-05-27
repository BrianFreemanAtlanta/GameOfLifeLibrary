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
        Assert.AreEqual(0, board.Cells.Count);
    }
    [TestMethod]
    public void CanAddCellToBoard()
    {
        var board = new Board();
        board.Add(new Cell());
        Assert.AreEqual(1, board.Cells.Count);
    }
    [TestMethod]
    public void CountOnlyLiveCells()
    {
        var board = new Board();
        Cell cell = new Cell() { IsAlive=false};
        board.Cells.Add(cell);
        Assert.AreEqual(0, board.Cells.Count);
    }
}
