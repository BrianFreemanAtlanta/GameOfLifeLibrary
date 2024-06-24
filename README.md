# Game of life Project
I Decided to do a full coding of Conway’s Game of Life per the “Global Day Of Coding” rules given as a pet project to be coding "something".
1.	Program a representative system for Conway’s Game of Life
    a.	Cells obey rules for living or dying per original Rules
    b.	Infinite coordinate system
2.	Jumped into implementation doing a TDD approach
3.	Started with Cell “next state” rules based on number of neighbors
4.	Burned time solving “infinite coordinates” problem using lists of numbers instead of single number for coordinates. i.e. Point =  { x: [x1,x2,x3], y: [y1]}
5.	Realized for MVP could do integer point.
6.	Switched cell/board coordinates to integer point
7.	Added board with “getNeighbor” that adds “dead cell” if the cell does not exist
a.	Breaks rule that “read” does not have side effects
8.	Started calculations for “next state” on board
9.	Realized as designed would need “special” handling for dead cells
10.	Realized I did rookie mistake and started into my TDD solution without breaking project down into tasks and MVP iterative solutions for fast feedback
11.	Step back regroup
## Ultimate Goal:
- Full web representation of Conway’s Game of Life
    - Handle “infinite grid”
    - UI’s in different presentation layers
        - Vue3
        - Angular
        - React
        - Blazor
        - WPF
- Web service with “observable” end point that streams board/cell states as they progress
- Simple UI to input starting cells, or start from catalog of interesting patterns, perhaps shape combiner for pattern to start, perhaps “drawing” capabilities for starting pattern
- Zoom in/out capabilities and “pan” functionality.
- Perhaps change color patterns for UI (cell colors, “dark” mode??)
## Let’s start with defining a first round MVP
1.	Cells are on an integer coordinate system
2.	Cells that leave boundaries are “lost” and die
3.	UI displays cells that are in its “display window” ignores cells outside the window
4.	UI allows entries of array of cells to start game
5.	UI has Button to increment “state” and get next step in “game”
6.	UI updates display of cells within its display window

To achieve this we will choose single UI framework for POC/MVP. Will have web server in C# “minimal API” with endpoints to support this functionality. There is a single game that is running. Will add on handling multiple “games” for multiple people later.
Server endpoints:
1.	Board HTTP POST – 
    a.	Inputs array of x,y coordinates of cells to start the game
    b.	Returns array of x,y coordinates of game cells
    c.	Resets game to starting state or erases any current “running” game
    d. Returns array of x, y coordinates of the game board cells
2.	Board HTTP GET (no ID for now)
    a.	Returns cells that are on the game
3.	Board/Next HTTP GET
    a.	Advances the game one step
    b.	Returns array of x,y coordinates of the live game cells
4.  Board/Cells HTTP PUT
    a. Accepts list of X,Y coordinates of Cells to place on the grid
    b. Does not reset board
    c. Returns array of x, y coordinates of game live cells on the board
