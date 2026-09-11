using Centraly.Api.Abstractions.Consts;
using Centraly.Api.Contracts.Common;
using Centraly.Api.Contracts.Drawer;
using Centraly.Api.Extensions;
using Centraly.Api.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Centraly.Api.Controllers;

[Route("drawers")]
[ApiController]
[Authorize]
public class DrawerController(IDrawerService _drawerService) : ControllerBase
{
    private bool IsDrawerAccessAllowed(int? requestedType)
    {
        if (User.IsInRole(DefaultRoles.Admin.Name) || User.IsInRole(DefaultRoles.Manager.Name)) return true;
        if (User.IsInRole(DefaultRoles.Salesperson.Name)) return requestedType == 1;
        if (User.IsInRole(DefaultRoles.Technician.Name)) return requestedType == 2;
        return false;
    }

    [HttpPost("open")]
    public async Task<IActionResult> OpenSession([FromBody] OpenSessionRequest request, CancellationToken ct)
    {
        if (!IsDrawerAccessAllowed(request.Type)) return Forbid();
        
        var result = await _drawerService.OpenSessionAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("close")]
    public async Task<IActionResult> CloseSession([FromQuery] int type = 1, CancellationToken ct = default)
    {
        if (!IsDrawerAccessAllowed(type)) return Forbid();
        
        var result = await _drawerService.CloseSessionAsync(type, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetActiveSession([FromQuery] int type = 1, CancellationToken ct = default)
    {
        if (!IsDrawerAccessAllowed(type)) return Forbid();
        
        var result = await _drawerService.GetActiveSessionAsync(type, ct);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost("transactions/manual")]
    public async Task<IActionResult> AddManualTransaction([FromBody] AddManualTransactionRequest request, CancellationToken ct)
    {
        // Category 1 is Sales/General, Category 2 is Maintenance
        var type = request.Category == DrawerTransactionCategory.Maintenance ? 2 : 1; 
        if (!IsDrawerAccessAllowed(type)) return Forbid();

        var result = await _drawerService.AddManualTransactionAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("history")]
    public async Task<IActionResult> GetSessionsHistory([FromQuery] RequestFilters filters, [FromQuery] int? type = null, CancellationToken ct = default)
    {
        if (type.HasValue && !IsDrawerAccessAllowed(type.Value)) return Forbid();
        
        // If type is null (requesting all), restrict it for restricted roles
        if (!type.HasValue && !User.IsInRole(DefaultRoles.Admin.Name) && !User.IsInRole(DefaultRoles.Manager.Name))
        {
            type = User.IsInRole(DefaultRoles.Technician.Name) ? 2 : 1;
        }

        var result = await _drawerService.GetSessionsHistoryAsync(filters, type, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("history/{id}")]
    public async Task<IActionResult> GetSessionById(string id, CancellationToken ct = default)
    {
        var result = await _drawerService.GetSessionByIdAsync(id, ct);
        if (!result.IsSuccess) return NotFound(result.Error);
        
        // Ensure they are allowed to see this specific session
        if (!IsDrawerAccessAllowed(result.Value.Type)) return Forbid();
        
        return Ok(result.Value);
    }
}
