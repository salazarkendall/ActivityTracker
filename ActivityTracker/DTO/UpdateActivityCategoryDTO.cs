using System.ComponentModel.DataAnnotations;

namespace ActivityTracker.DTO;

public class UpdateActivityCategoryDTO
{
  [Required]
  public Guid CategoryId { get; set; }
}
