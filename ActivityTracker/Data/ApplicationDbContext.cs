using ActivityTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace ActivityTracker.Data;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }

  public DbSet<Category> Categories { get; set; }
  public DbSet<Activity> Activities { get; set; }
}
