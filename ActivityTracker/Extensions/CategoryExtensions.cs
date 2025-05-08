using ActivityTracker.Entities;

namespace ActivityTracker.Extensions;

public static class CategoryExtensions
{
  public static Category FromDTO(this CategoryRequestDTO dto)
  {
    return new Category
    {
      Name = dto.Name,
      Description = dto.Description,
      Color = dto.Color,
      CreatedAt = DateTime.UtcNow
    };
  }
}
