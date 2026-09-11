using Centraly.Api.Services;

namespace Centraly.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(ILogger<AuthController> logger,
    IAuthService authService) : ControllerBase
{

    private readonly ILogger<AuthController> _logger = logger;
    private readonly IAuthService _authService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var authResult = await _authService.LoginAsync(request, cancellationToken);
            return authResult.IsSuccess ? Ok(authResult.Value) : authResult.ToProblem();
        }
        catch (OperationCanceledException)
        {
            return StatusCode(499);
        }
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var authResult = await _authService.GetRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);
            return authResult.IsSuccess ? Ok(authResult.Value) : authResult.ToProblem();
        }
        catch (OperationCanceledException)
        {
            return StatusCode(499);
        }
    }

    [HttpPost("revoke-refresh-token")]
    public async Task<IActionResult> RevokeRefreshToken([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _authService.RevokeRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);
            return result.IsSuccess ? Ok() : result.ToProblem();
        }
        catch (OperationCanceledException)
        {
            return StatusCode(499);
        }
    }

}