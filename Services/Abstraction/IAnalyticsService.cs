namespace Centraly.Api.Services.Abstraction;

public interface IAnalyticsService
{
    Task<Result<AnalyticsSummaryResponse>> GetSummaryAsync(AnalyticsRangeFilter filter, CancellationToken ct = default);
    Task<Result<List<TopProductResponse>>> GetTopProductsAsync(AnalyticsRangeFilter filter, CancellationToken ct = default);
    Task<Result<List<TopCustomerResponse>>> GetTopCustomersAsync(AnalyticsRangeFilter filter, CancellationToken ct = default);
    Task<Result<List<SalesTrendPointResponse>>> GetSalesTrendAsync(AnalyticsRangeFilter filter, CancellationToken ct = default);

    Task<Result<SupplierAnalyticsSummaryResponse>> GetSupplierSummaryAsync(AnalyticsRangeFilter filter, CancellationToken ct = default);
    Task<Result<List<TopSupplierResponse>>> GetTopSuppliersAsync(AnalyticsRangeFilter filter, CancellationToken ct = default);
    Task<Result<List<PurchaseTrendPointResponse>>> GetPurchaseTrendAsync(AnalyticsRangeFilter filter, CancellationToken ct = default);

    Task<Result<MaintenanceAnalyticsSummaryResponse>> GetMaintenanceSummaryAsync(AnalyticsRangeFilter filter, CancellationToken ct = default);

    Task<Result<InventoryAnalyticsSummaryResponse>> GetInventorySummaryAsync(CancellationToken ct = default);
    Task<Result<List<SlowMovingProductResponse>>> GetSlowMovingProductsAsync(AnalyticsRangeFilter filter, CancellationToken ct = default);

    Task<Result<FinanceAnalyticsSummaryResponse>> GetFinanceSummaryAsync(AnalyticsRangeFilter filter, CancellationToken ct = default);
    Task<Result<List<ExpenseCategoryBreakdownResponse>>> GetExpenseBreakdownAsync(AnalyticsRangeFilter filter, CancellationToken ct = default);
}
