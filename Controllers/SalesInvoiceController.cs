namespace Centraly.Api.Controllers;

[Route("sales-invoices")]
[ApiController]
[Authorize(Roles = "Admin,Manager,Salesperson")]
public class SalesInvoiceController(ISalesInvoiceService _salesInvoiceService) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> AddInvoice([FromBody] CreateSalesInvoiceRequest request, CancellationToken ct)
    {
        var result = await _salesInvoiceService.AddInvoiceAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInvoice(string id, CancellationToken ct)
    {
        var result = await _salesInvoiceService.GetInvoiceAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllInvoices([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _salesInvoiceService.GetAllInvoicesAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}


