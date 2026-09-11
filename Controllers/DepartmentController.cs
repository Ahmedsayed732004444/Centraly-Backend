namespace Centraly.Api.Controllers;

[Route("departments")]
[ApiController]
public class DepartmentController(IDepartmentService _departmentService) : ControllerBase
{

    [HttpPost]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentRequest request, CancellationToken ct)
    {
        var result = await _departmentService.AddDepartmentAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Manager,Salesperson,Technician")]
    public async Task<IActionResult> GetDepartment(string id, CancellationToken ct)
    {
        var result = await _departmentService.GetDepartmentAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Manager,Salesperson,Technician")]
    public async Task<IActionResult> GetAllDepartments([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _departmentService.GetAllDepartmentsAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> UpdateDepartment(string id, [FromBody] UpdateDepartmentRequest request, CancellationToken ct)
    {
        var result = await _departmentService.UpdateDepartmentAsync(id, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> DeleteDepartment(string id, CancellationToken ct)
    {
        var result = await _departmentService.DeleteDepartmentAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
