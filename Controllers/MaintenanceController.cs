using Centraly.Api.Contracts.Maintenance;

namespace Centraly.Api.Controllers;

[Route("maintenance")]
[ApiController]
[Authorize(Roles = "Admin,Manager,Technician")]
public class MaintenanceController(IMaintenanceService _maintenanceService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateMaintenance([FromBody] CreateMaintenanceRequest request, CancellationToken ct)
    {
        var result = await _maintenanceService.CreateMaintenanceAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMaintenance(string id, [FromBody] UpdateMaintenanceRequest request, CancellationToken ct)
    {
        var result = await _maintenanceService.UpdateMaintenanceAsync(id, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("{id}/deliver")]
    public async Task<IActionResult> DeliverMaintenance(string id, CancellationToken ct)
    {
        var result = await _maintenanceService.DeliverMaintenanceAsync(id, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("{id}/return")]
    public async Task<IActionResult> ReturnMaintenance(string id, CancellationToken ct)
    {
        var result = await _maintenanceService.ReturnMaintenanceAsync(id, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMaintenance([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _maintenanceService.GetAllMaintenanceAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken ct)
    {
        var result = await _maintenanceService.GetByIdAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }
}
