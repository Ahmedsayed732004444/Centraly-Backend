using Centraly.Api.Contracts.Roles;
using Centraly.Api.Services;

namespace Centraly.Api.Controllers;

[Route("roles")]
[ApiController]
[Authorize(Roles = "Admin,Manager")]
public class RoleController(IRoleService roleService) : ControllerBase
{
    private readonly IRoleService _roleService = roleService;

    [HttpGet]
    public async Task<IActionResult> GetAllRoles([FromQuery] bool includeDisabled, CancellationToken ct)
    {
        var roles = await _roleService.GetAllAsync(includeDisabled, ct);
        return Ok(roles);
    }

    [HttpGet("permissions")]
    public IActionResult GetAllPermissions()
    {
        return Ok(Permissions.GetAllPermissions());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRole(string id)
    {
        var result = await _roleService.GetAsync(id);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] RoleRequest request)
    {
        var result = await _roleService.AddAsync(request);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(string id, [FromBody] RoleRequest request)
    {
        var result = await _roleService.UpdateAsync(id, request);
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [HttpPatch("{id}/toggle-status")]
    public async Task<IActionResult> ToggleRoleStatus(string id)
    {
        var result = await _roleService.ToggleStatusAsync(id);
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
}
