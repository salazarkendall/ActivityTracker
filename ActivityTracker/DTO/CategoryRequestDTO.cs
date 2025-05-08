
using System.ComponentModel.DataAnnotations;

public class CategoryRequestDTO
{
  [Required]
  [StringLength(50)]
  public required string Name { get; set; }
  [StringLength(150)]
  public string Description { get; set; } = string.Empty;
  [StringLength(9)]
  public string Color { get; set; } = string.Empty;
}
