using GameOfLifeLibrary;

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
}
