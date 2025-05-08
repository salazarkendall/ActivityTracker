using System.ComponentModel.DataAnnotations;
using ActivityTracker.Constants;
using ActivityTracker.Data;
using ActivityTracker.Entities;
using ActivityTracker.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActivityTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
  private readonly ApplicationDbContext context;
  public CategoryController(ApplicationDbContext context)
  {
    this.context = context;
  }

  [HttpGet]
  public async Task<List<Category>> Get()
  {
    var categories = await context.Categories.ToListAsync();
    return categories;
  }

  [HttpGet("{id:guid}", Name = CategoryEndpointNames.GET_BY_ID)]
  public async Task<Category?> Get(Guid id)
  {
    var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
    return category;
  }

  [HttpPost(Name = CategoryEndpointNames.POST)]
  public async Task<ActionResult> Post(CategoryRequestDTO request)
  {
    var newCategory = request.FromDTO();
    context.Categories.Add(newCategory);
    await context.SaveChangesAsync();
    return CreatedAtRoute(CategoryEndpointNames.GET_BY_ID, new { id = newCategory.Id }, newCategory);
  }

  [HttpDelete("{id:guid}", Name = CategoryEndpointNames.DELETE)]
  public async Task<ActionResult> Delete(Guid id)
  {
    var category = await context.Categories.FirstOrDefaultAsync(category => category.Id == id);
    if (category is null) return NotFound();
    context.Categories.Remove(category);
    await context.SaveChangesAsync();
    return Ok();
  }
}
