namespace Centraly.Api.Contracts.Analytics;

// Deliberately not RequestFilters - that record carries 12 filters (category, stock
// status, supplier, etc.) that don't apply here and would bloat the query string /
// Swagger surface for a screen that only ever filters by date range and a top-N limit.
public record AnalyticsRangeFilter
{
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public int Limit { get; init; } = 10;
}

public record AnalyticsSummaryResponse(
    decimal TotalRevenue,
    int InvoiceCount,
    decimal AverageInvoiceValue,
    decimal NetProfit);

public record TopProductResponse(
    string ProductId,
    string ProductName,
    int QuantitySold,
    decimal Revenue);

public record TopCustomerResponse(
    string CustomerId,
    string CustomerName,
    decimal TotalPurchases,
    int InvoiceCount);

public record SalesTrendPointResponse(
    DateTime Date,
    decimal Revenue,
    int InvoiceCount);

// الموردين والمشتريات
public record SupplierAnalyticsSummaryResponse(
    decimal TotalPurchases,
    int InvoiceCount,
    decimal AveragePurchaseValue,
    decimal TotalOutstandingPayable);

public record TopSupplierResponse(
    string SupplierId,
    string SupplierName,
    decimal TotalPurchases,
    int InvoiceCount);

public record PurchaseTrendPointResponse(
    DateTime Date,
    decimal Amount,
    int InvoiceCount);

// الصيانة
public record MaintenanceAnalyticsSummaryResponse(
    decimal TotalRevenue,
    decimal TotalProfit,
    int TicketCount,
    decimal AverageTicketValue,
    int PendingCount,
    int DeliveredCount,
    int ReturnedCount);

// المخزون والمنتجات المتعثرة
public record InventoryAnalyticsSummaryResponse(
    decimal TotalInventoryValue,
    int TotalProductsCount,
    int LowStockCount,
    int OutOfStockCount);

public record SlowMovingProductResponse(
    string ProductId,
    string ProductName,
    int QuantityInStock,
    int QuantitySoldInPeriod);

// الماليات والأرباح (حركة الدرج العامة، كل الورديات)
public record FinanceAnalyticsSummaryResponse(
    decimal TotalDrawerIncome,
    decimal TotalDrawerExpense,
    decimal NetCashFlow);

public record ExpenseCategoryBreakdownResponse(
    string Category,
    decimal TotalAmount,
    int Count);
