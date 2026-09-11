using Centraly.Api.Contracts.Users;
using Centraly.Api.Services;
namespace Centraly.Api.Controllers;

[Route("users")]
[ApiController]
[Authorize(Roles = "Admin,Manager")]
public class UserController(IUserService _userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUsers(CancellationToken ct)
    {
        var users = await _userService.GetAllAsync(ct);
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        var result = await _userService.GetAsync(id);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken ct)
    {
        var result = await _userService.AddAsync(request, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserRequest request, CancellationToken ct)
    {
        var result = await _userService.UpdateAsync(id, request, ct);
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
}
