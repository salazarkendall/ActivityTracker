using ActivityTracker.Data;
using ActivityTracker.DTO;
using ActivityTracker.Entities;
using ActivityTracker.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ActivityTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class ActivityController : ControllerBase
{
  private readonly ApplicationDbContext context;

  public ActivityController(ApplicationDbContext context)
  {
    this.context = context;
  }

  [HttpGet]
  public async Task<List<Activity>> Get()
  {
    var activities = await context.Activities.ToListAsync();
    return activities;
  }

  [HttpGet("{id:guid}")]
  public async Task<Activity?> Get(Guid id)
  {
    var activity = await context.Activities.Include(a => a.Category).FirstOrDefaultAsync(a => a.Id == id);
    return activity;
  }

  [HttpPost]
  public async Task<Activity> Post(ActivityRequestDTO request)
  {
    var newActivity = request.FromDTO();
    context.Activities.Add(newActivity);
    await context.SaveChangesAsync();
    return newActivity;
  }

  [HttpPut("{id:guid}")]
  public async Task<ActionResult<Activity?>> Update(Guid id, [FromBody] UpdateActivityCategoryDTO dto)
  {
    var activity = await context.Activities.FirstOrDefaultAsync(a => a.Id == id);
    if (activity is null) return NotFound();
    var validCategoryId = await context.Categories.AnyAsync(c => c.Id == dto.CategoryId);
    if (!validCategoryId) return BadRequest();
    activity.CategoryId = dto.CategoryId;
    await context.SaveChangesAsync();
    return Ok(activity);
  }

  [HttpDelete("{id:guid}")]
  public async Task<ActionResult> Delete(Guid id)
  {
    var activity = await context.Activities.FirstOrDefaultAsync(a => a.Id == id);
    if (activity is not null) context.Activities.Remove(activity);
    return NoContent();
  }
}
