using Sorting_Algorithm_Server.Server.Snippets;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// app.UseWebSockets();

app.UseCors("AllowAll");

app.MapControllers();

app.Run("https://localhost:7000");


