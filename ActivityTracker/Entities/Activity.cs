using System.ComponentModel.DataAnnotations;

namespace ActivityTracker.Entities;

public class Activity
{
  [Key]
  public Guid Id { get; set; }
  public Guid? CategoryId { get; set; }
  [Required]
  [StringLength(100)]
  public string Title { get; set; } = string.Empty;
  public DateTime StartTime { get; set; }
  public DateTime EndTime { get; set; }

  // Navigation Prorperties
  public Category? Category { get; set; }
}
