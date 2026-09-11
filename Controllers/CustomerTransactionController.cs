namespace Centraly.Api.Controllers;

[Route("customers/{customerId}/transactions")]
[ApiController]
[Authorize(Roles = "Admin,Manager,Salesperson")]

public class CustomerTransactionController(ICustomerTransactionService _transactionService) : ControllerBase
{
    [HttpPost("payments")]
    public async Task<IActionResult> AddPayment(string customerId, [FromBody] CreateCustomerPaymentRequest request, CancellationToken ct)
    {
        var result = await _transactionService.AddPaymentAsync(customerId, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("returns")]
    public async Task<IActionResult> AddReturn(string customerId, [FromBody] CreateCustomerReturnRequest request, CancellationToken ct)
    {
        var result = await _transactionService.AddReturnAsync(customerId, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("statement")]
    public async Task<IActionResult> GetStatement(string customerId, CancellationToken ct)
    {
        var result = await _transactionService.GetCustomerStatementAsync(customerId, ct);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }
}

