namespace Centraly.Api.Controllers;

[Route("analytics")]
[ApiController]
[Authorize(Roles = "Admin,Manager")]
public class AnalyticsController(IAnalyticsService analyticsService) : ControllerBase
{
    [HttpGet("summary")]
    public async Task<IActionResult> GetSummary([FromQuery] AnalyticsRangeFilter filter, CancellationToken ct)
    {
        var result = await analyticsService.GetSummaryAsync(filter, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("top-products")]
    public async Task<IActionResult> GetTopProducts([FromQuery] AnalyticsRangeFilter filter, CancellationToken ct)
    {
        var result = await analyticsService.GetTopProductsAsync(filter, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("top-customers")]
    public async Task<IActionResult> GetTopCustomers([FromQuery] AnalyticsRangeFilter filter, CancellationToken ct)
    {
        var result = await analyticsService.GetTopCustomersAsync(filter, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("sales-trend")]
    public async Task<IActionResult> GetSalesTrend([FromQuery] AnalyticsRangeFilter filter, CancellationToken ct)
    {
        var result = await analyticsService.GetSalesTrendAsync(filter, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("suppliers/summary")]
    public async Task<IActionResult> GetSupplierSummary([FromQuery] AnalyticsRangeFilter filter, CancellationToken ct)
    {
        var result = await analyticsService.GetSupplierSummaryAsync(filter, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("suppliers/top")]
    public async Task<IActionResult> GetTopSuppliers([FromQuery] AnalyticsRangeFilter filter, CancellationToken ct)
    {
        var result = await analyticsService.GetTopSuppliersAsync(filter, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("suppliers/purchase-trend")]
    public async Task<IActionResult> GetPurchaseTrend([FromQuery] AnalyticsRangeFilter filter, CancellationToken ct)
    {
        var result = await analyticsService.GetPurchaseTrendAsync(filter, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("maintenance/summary")]
    public async Task<IActionResult> GetMaintenanceSummary([FromQuery] AnalyticsRangeFilter filter, CancellationToken ct)
    {
        var result = await analyticsService.GetMaintenanceSummaryAsync(filter, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("inventory/summary")]
    public async Task<IActionResult> GetInventorySummary(CancellationToken ct)
    {
        var result = await analyticsService.GetInventorySummaryAsync(ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("inventory/slow-moving")]
    public async Task<IActionResult> GetSlowMovingProducts([FromQuery] AnalyticsRangeFilter filter, CancellationToken ct)
    {
        var result = await analyticsService.GetSlowMovingProductsAsync(filter, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("finance/summary")]
    public async Task<IActionResult> GetFinanceSummary([FromQuery] AnalyticsRangeFilter filter, CancellationToken ct)
    {
        var result = await analyticsService.GetFinanceSummaryAsync(filter, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("finance/expense-breakdown")]
    public async Task<IActionResult> GetExpenseBreakdown([FromQuery] AnalyticsRangeFilter filter, CancellationToken ct)
    {
        var result = await analyticsService.GetExpenseBreakdownAsync(filter, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
