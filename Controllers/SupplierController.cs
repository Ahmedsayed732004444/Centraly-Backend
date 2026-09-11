namespace Centraly.Api.Controllers;

[Route("suppliers")]
[ApiController]
[Authorize(Roles = "Admin,Manager")]
public class SupplierController(ISupplierService _supplierService) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierRequest request, CancellationToken ct)
    {
        var result = await _supplierService.AddSupplierAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSupplier(string id, CancellationToken ct)
    {
        var result = await _supplierService.GetSupplierAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSuppliers([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _supplierService.GetAllSuppliersAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSupplier(string id, [FromBody] UpdateSupplierRequest request, CancellationToken ct)
    {
        var result = await _supplierService.UpdateSupplierAsync(id, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSupplier(string id, CancellationToken ct)
    {
        var result = await _supplierService.DeleteSupplierAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}/statement")]
    public async Task<IActionResult> GetSupplierStatement(string id, [FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _supplierService.GetSupplierStatementAsync(id, filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}/batches")]
    public async Task<IActionResult> GetSupplierAvailableBatches(string id, CancellationToken ct)
    {
        var result = await _supplierService.GetSupplierAvailableBatchesAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}

