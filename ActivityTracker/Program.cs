using ActivityTracker.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services:
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Add middlewares:

app.Run();