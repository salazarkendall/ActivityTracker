using System.ComponentModel.DataAnnotations;

namespace ActivityTracker.Entities;

public class Category
{
  [Key]
  public Guid Id { get; set; }
  [Required]
  [StringLength(50)]
  public required string Name { get; set; }
  [StringLength(150)]
  public string Description { get; set; } = string.Empty;
  [StringLength(9)]
  public string Color { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }

  // Navigation Properties
  public ICollection<Activity> Activities { get; set; } = [];
}
