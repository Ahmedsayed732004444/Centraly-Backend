namespace Centraly.Api.Controllers;

[Route("categories")]
[ApiController]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpPost]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request, CancellationToken ct)
    {
        var result = await _categoryService.AddCategoryAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Manager,Salesperson,Technician")]
    public async Task<IActionResult> GetCategory(string id, CancellationToken ct)
    {
        var result = await _categoryService.GetCategoryAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Manager,Salesperson,Technician")]
    public async Task<IActionResult> GetAllCategories([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _categoryService.GetAllCategoriesAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> UpdateCategory(string id, [FromBody] UpdateCategoryRequest request, CancellationToken ct)
    {
        var result = await _categoryService.UpdateCategoryAsync(id, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> DeleteCategory(string id, CancellationToken ct)
    {
        var result = await _categoryService.DeleteCategoryAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}




