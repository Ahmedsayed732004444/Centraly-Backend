namespace Centraly.Api.Controllers;

[Route("sales-returns")]
[ApiController]
[Authorize(Roles = "Admin,Manager,Salesperson")]
public class SalesReturnController(ISalesReturnService _salesReturnService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddReturn([FromBody] CreateCustomerReturnRequest request, CancellationToken ct)
    {
        var result = await _salesReturnService.AddReturnAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReturn(string id, CancellationToken ct)
    {
        var result = await _salesReturnService.GetReturnAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllReturns([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _salesReturnService.GetAllReturnsAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}

