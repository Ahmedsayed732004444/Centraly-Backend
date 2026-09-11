namespace Centraly.Api.Controllers;

[Route("purchase-invoices")]
[ApiController]
[Authorize(Roles = "Admin,Manager")]
public class PurchaseInvoiceController(IPurchaseInvoiceService _invoiceService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePurchaseInvoice([FromBody] CreatePurchaseInvoiceRequest request, CancellationToken ct)
    {
        var result = await _invoiceService.AddPurchaseInvoiceAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPurchaseInvoice(string id, CancellationToken ct)
    {
        var result = await _invoiceService.GetPurchaseInvoiceAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPurchaseInvoices([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _invoiceService.GetAllPurchaseInvoicesAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
