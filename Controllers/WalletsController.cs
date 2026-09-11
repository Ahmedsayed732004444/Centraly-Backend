namespace Centraly.Api.Controllers;

[Route("wallets")]
[ApiController]
public class WalletsController(IWalletService _walletService) : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Admin,Manager,Salesperson")]
    public async Task<IActionResult> GetWallets([FromQuery] PaginationFilter filter, CancellationToken ct)
    {
        var result = await _walletService.GetAllWalletsAsync(filter, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> CreateWallet([FromForm] CreateWalletRequest request, CancellationToken ct)
    {
        var result = await _walletService.CreateWalletAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("{walletId}/operations")]
    [Authorize(Roles = "Admin,Manager,Salesperson")]

    public async Task<IActionResult> ProcessOperation(
        [FromRoute] string walletId, [FromBody] ProcessOperationRequest request, CancellationToken ct)
    {
        var result = await _walletService.ProcessOperationAsync(request with { WalletId = walletId }, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{walletId}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> UpdateWallet(
        [FromRoute] string walletId, [FromForm] UpdateWalletRequest request, CancellationToken ct)
    {
        var result = await _walletService.UpdateWalletAsync(walletId, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{walletId}")]
    [Authorize(Roles = "Admin,Manager,Salesperson")]
    public async Task<IActionResult> GetWallet([FromRoute] string walletId, CancellationToken ct)
    {
        var result = await _walletService.GetWalletByIdAsync(walletId, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("operations")]
    [Authorize(Roles = "Admin,Manager,Salesperson")]
    public async Task<IActionResult> GetOperations([FromQuery] WalletOperationFilter filter, CancellationToken ct)
    {
        var result = await _walletService.GetWalletOperationsAsync(filter, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("operations/summary")]
    [Authorize(Roles = "Admin,Manager,Salesperson")]
    public async Task<IActionResult> GetOperationsSummary([FromQuery] WalletOperationFilter filter, CancellationToken ct)
    {
        var result = await _walletService.GetWalletOperationsSummaryAsync(filter, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
