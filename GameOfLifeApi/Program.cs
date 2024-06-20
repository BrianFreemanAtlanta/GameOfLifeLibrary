using GameOfLifeLibrary;
using System.Drawing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


var board = new Board();
List<Point> firstCells = [new(0, 0), new(1, 0), new(2, 0)];
var bInit = false;

app.MapGet("/board", () =>
{
    if (!bInit)
    {
        foreach (var item in firstCells)
        {
            board.Add(new(item.X, item.Y));
        }
        bInit=true;
    }
    var list = board.GetCells().Select(c => c.Point).ToList();
    return list;
})
.WithName("GetBoard")
.WithOpenApi();

app.MapGet("/board/next", () =>
{
    if (!bInit)
    {
        foreach (var item in firstCells)
        {
            board.Add(new(item.X, item.Y));
        }
        bInit = true;
    }
    board.SetNextStep();
    var list = board.GetCells().Select(c => c.Point).ToList();
    return list;
})
.WithName("GetBoardNext")
.WithOpenApi();



app.Run();

