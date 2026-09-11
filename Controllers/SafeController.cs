namespace Centraly.Api.Controllers;

[Route("Safe")]
[ApiController]
[Authorize(Roles = "Admin,Manager")]
public class SafeController(ISafeService _safeService) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateSafe(CreateSafeRequest request, CancellationToken ct)
    {
        var result = await _safeService.CreateSafeAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetSafes(CancellationToken ct)
    {
        var result = await _safeService.GetSafesAsync(ct);
        return Ok(result.Value);
    }

    [HttpPost("{safeId}/deposit")]
    public async Task<IActionResult> DepositFromDrawer(string safeId, ReceiveDrawerDepositRequest request, CancellationToken ct)
    {
        var result = await _safeService.DepositFromDrawerAsync(safeId, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("{safeId}/manual-transaction")]
    public async Task<IActionResult> AddManualTransaction(string safeId, [FromBody] AddManualSafeTransactionRequest request, CancellationToken ct)
    {
        var result = await _safeService.AddManualTransactionAsync(safeId, request.Type, request.Category, request.Amount, 0, request.Notes, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{safeId}/transactions")]
    public async Task<IActionResult> GetSafeTransactions(string safeId, [FromQuery] FinanceFilters filters, CancellationToken ct)
    {
        var result = await _safeService.GetSafeTransactionsAsync(safeId, filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}



