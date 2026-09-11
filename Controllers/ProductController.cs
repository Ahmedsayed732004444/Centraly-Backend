namespace Centraly.Api.Controllers;

[Route("products")]
[ApiController]
public class ProductController(IProductService _productService) : ControllerBase
{
    [Authorize(Roles = "Admin,Manager")]
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromForm] CreateProductRequest request, CancellationToken ct)
    {
        var result = await _productService.AddProductAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Manager,Salesperson,Technician")]
    public async Task<IActionResult> GetProduct(string id, CancellationToken ct)
    {
        var result = await _productService.GetProductAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Manager,Salesperson,Technician")]
    public async Task<IActionResult> GetAllProducts([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _productService.GetAllProductsAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}/suppliers")]
    [Authorize(Roles = "Admin,Manager,Salesperson,Technician")]
    public async Task<IActionResult> GetProductSuppliers(string id, CancellationToken ct)
    {
        var result = await _productService.GetProductSuppliersAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> UpdateProduct(string id, [FromForm] UpdateProductRequest request, CancellationToken ct)
    {
        var result = await _productService.UpdateProductAsync(id, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPatch("{id}/adjust-quantity")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> AdjustQuantity(string id, [FromBody] AdjustProductQuantityRequest request, CancellationToken ct)
    {
        var result = await _productService.AdjustQuantityAsync(id, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> DeleteProduct(string id, CancellationToken ct)
    {
        var result = await _productService.DeleteProductAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
