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
        board.Cells.Add(new Cell());
        Assert.AreEqual(1, board.Cells.Count);
    }
}
