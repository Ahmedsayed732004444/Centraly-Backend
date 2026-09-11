
namespace Centraly.Api.Controllers;

[ApiController]
[Route("ownerTransactions")]
[Authorize(Roles = "Admin,Manager")]
public class OwnerTransactionController(IOwnerTransactionService _ownerTransactionService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateOwnerTransaction([FromBody] CreateOwnerTransactionRequest request, CancellationToken cancellationToken)
    {

        var result = await _ownerTransactionService.CreateOwnerTransactionAsync(request, User.GetUserId()!, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetOwnerTransactions(CancellationToken cancellationToken)
    {
        var result = await _ownerTransactionService.GetOwnerTransactionsAsync(cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}

