namespace Centraly.Api.Controllers;

[Route("customers")]
[ApiController]
[Authorize(Roles = "Admin,Manager,Salesperson")]
public class CustomerController(ICustomerService _customerService) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request, CancellationToken ct)
    {
        var result = await _customerService.AddCustomerAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(string id, CancellationToken ct)
    {
        var result = await _customerService.GetCustomerAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _customerService.GetAllCustomersAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}/debt-history")]
    public async Task<IActionResult> GetCustomerDebtHistory(string id, CancellationToken ct)
    {
        var result = await _customerService.GetCustomerWithDebtHistoryAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(string id, [FromBody] UpdateCustomerRequest request, CancellationToken ct)
    {
        var result = await _customerService.UpdateCustomerAsync(id, request, User.GetUserId(), ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> DeleteCustomer(string id, CancellationToken ct)
    {
        var result = await _customerService.DeleteCustomerAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
