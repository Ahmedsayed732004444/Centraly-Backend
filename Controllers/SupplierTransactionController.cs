namespace Centraly.Api.Controllers;

[Route("supplier-transactions")]
[ApiController]
[Authorize(Roles = "Admin,Manager")]
public class SupplierTransactionController(ISupplierTransactionService _transactionService) : ControllerBase
{


    [HttpPost("payments")]
    public async Task<IActionResult> CreatePayment([FromBody] CreateSupplierPaymentRequest request, CancellationToken ct)
    {
        var result = await _transactionService.AddPaymentAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("payments/{id}")]
    public async Task<IActionResult> GetPayment(string id, CancellationToken ct)
    {
        var result = await _transactionService.GetPaymentAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("payments")]
    public async Task<IActionResult> GetAllPayments([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _transactionService.GetAllPaymentsAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }


    [HttpPost("returns")]
    public async Task<IActionResult> CreateReturn([FromBody] CreateSupplierReturnRequest request, CancellationToken ct)
    {
        var result = await _transactionService.AddReturnAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("returns/{id}")]
    public async Task<IActionResult> GetReturn(string id, CancellationToken ct)
    {
        var result = await _transactionService.GetReturnAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("returns")]
    public async Task<IActionResult> GetAllReturns([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _transactionService.GetAllReturnsAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
