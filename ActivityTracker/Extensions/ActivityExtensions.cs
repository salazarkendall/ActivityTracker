using ActivityTracker.DTO;
using ActivityTracker.Entities;

namespace ActivityTracker.Extensions;

public static class ActivityExtensions
{
  public static Activity FromDTO(this ActivityRequestDTO activityRequestDTO)
  {
    return new()
    {
      Title = activityRequestDTO.Title,
      StartTime = DateTime.UtcNow
    };
  }
}
