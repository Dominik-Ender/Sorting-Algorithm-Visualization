using Sorting_Algorithm_Server.Server.Snippets;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseWebSockets();

app.MapControllers();

app.Run("https://localhost:7000");


