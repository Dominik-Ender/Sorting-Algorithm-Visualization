var ALLOWALL = "AllowAll";
var LOCALHOST = "https://localhost:7000";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options => {
    options.AddPolicy(ALLOWALL, policy => {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors(ALLOWALL);

app.MapControllers();

app.Run(LOCALHOST);
