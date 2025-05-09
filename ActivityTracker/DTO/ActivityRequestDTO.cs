using System.ComponentModel.DataAnnotations;

namespace ActivityTracker.DTO;

public class ActivityRequestDTO
{
  [Required]
  [StringLength(100)]
  public string Title { get; set; } = string.Empty;
}
