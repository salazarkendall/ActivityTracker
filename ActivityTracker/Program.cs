var builder = WebApplication.CreateBuilder(args);

// Add services:

var app = builder.Build();

// Add middlewares:

app.Run();