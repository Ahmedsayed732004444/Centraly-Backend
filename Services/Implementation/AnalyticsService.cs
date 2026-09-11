namespace Centraly.Api.Services.Implementation;

public class AnalyticsService(ApplicationDbContext dbContext) : IAnalyticsService
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    private IQueryable<Entities.Sales.Invoice> FilteredInvoices(AnalyticsRangeFilter filter) =>
        _dbContext.Invoices
            .Where(i => !i.IsDeleted)
            .Where(i => filter.StartDate == null || i.CreatedAt >= filter.StartDate)
            .Where(i => filter.EndDate == null || i.CreatedAt <= filter.EndDate);

    public async Task<Result<AnalyticsSummaryResponse>> GetSummaryAsync(AnalyticsRangeFilter filter, CancellationToken ct = default)
    {
        // GroupBy(_ => 1) collapses the whole filtered set into a single aggregate row
        // in one round trip, instead of three separate Count/Sum/Sum queries.
        var summary = await FilteredInvoices(filter)
            .GroupBy(_ => 1)
            .Select(g => new
            {
                Count = g.Count(),
                Revenue = g.Sum(i => i.TotalAmount),
                Profit = g.Sum(i => i.RecordedProfit)
            })
            .FirstOrDefaultAsync(ct);

        if (summary is null)
            return Result.Success(new AnalyticsSummaryResponse(0, 0, 0, 0));

        var average = summary.Count > 0 ? summary.Revenue / summary.Count : 0;
        return Result.Success(new AnalyticsSummaryResponse(summary.Revenue, summary.Count, average, summary.Profit));
    }

    public async Task<Result<List<TopProductResponse>>> GetTopProductsAsync(AnalyticsRangeFilter filter, CancellationToken ct = default)
    {
        var grouped = await FilteredInvoices(filter)
            .SelectMany(i => i.Items)
            .GroupBy(x => new { x.ProductId, ProductName = x.Product!.Name })
            .Select(g => new
            {
                g.Key.ProductId,
                g.Key.ProductName,
                Quantity = g.Sum(x => x.Quantity),
                Revenue = g.Sum(x => x.Quantity * x.UnitPrice)
            })
            .OrderByDescending(x => x.Quantity)
            .Take(filter.Limit)
            .ToListAsync(ct);

        var result = grouped
            .Select(x => new TopProductResponse(x.ProductId, x.ProductName ?? "منتج محذوف", x.Quantity, x.Revenue))
            .ToList();

        return Result.Success(result);
    }

    public async Task<Result<List<TopCustomerResponse>>> GetTopCustomersAsync(AnalyticsRangeFilter filter, CancellationToken ct = default)
    {
        // Cash sales (no CustomerId) can't be attributed to a customer, so they're
        // excluded rather than grouped under a meaningless "null" bucket.
        var grouped = await FilteredInvoices(filter)
            .Where(i => i.CustomerId != null)
            .GroupBy(i => new { i.CustomerId, CustomerName = i.Customer!.Name })
            .Select(g => new
            {
                g.Key.CustomerId,
                g.Key.CustomerName,
                Total = g.Sum(i => i.TotalAmount),
                Count = g.Count()
            })
            .OrderByDescending(x => x.Total)
            .Take(filter.Limit)
            .ToListAsync(ct);

        var result = grouped
            .Select(x => new TopCustomerResponse(x.CustomerId!, x.CustomerName, x.Total, x.Count))
            .ToList();

        return Result.Success(result);
    }

    public async Task<Result<List<SalesTrendPointResponse>>> GetSalesTrendAsync(AnalyticsRangeFilter filter, CancellationToken ct = default)
    {
        var grouped = await FilteredInvoices(filter)
            .GroupBy(i => i.CreatedAt.Date)
            .Select(g => new
            {
                Date = g.Key,
                Revenue = g.Sum(i => i.TotalAmount),
                Count = g.Count()
            })
            .OrderBy(x => x.Date)
            .ToListAsync(ct);

        var result = grouped
            .Select(x => new SalesTrendPointResponse(x.Date, x.Revenue, x.Count))
            .ToList();

        return Result.Success(result);
    }

    private IQueryable<Entities.Suppliers.PurchaseInvoice> FilteredPurchaseInvoices(AnalyticsRangeFilter filter) =>
        _dbContext.PurchaseInvoices
            .Where(i => !i.IsDeleted)
            .Where(i => filter.StartDate == null || i.InvoiceDate >= filter.StartDate)
            .Where(i => filter.EndDate == null || i.InvoiceDate <= filter.EndDate);

    public async Task<Result<SupplierAnalyticsSummaryResponse>> GetSupplierSummaryAsync(AnalyticsRangeFilter filter, CancellationToken ct = default)
    {
        var summary = await FilteredPurchaseInvoices(filter)
            .GroupBy(_ => 1)
            .Select(g => new
            {
                Count = g.Count(),
                Total = g.Sum(i => i.TotalAmount)
            })
            .FirstOrDefaultAsync(ct);

        // المديونية للموردين رصيد جاري محفوظ على الكيان نفسه (Supplier.DebtBalance)، مش
        // مجموع مشتق من الفواتير - نفس المنطق المستخدم في PurchaseInvoiceService/SupplierTransactionService.
        var totalOutstanding = await _dbContext.Suppliers
            .Where(s => !s.IsDeleted)
            .SumAsync(s => s.DebtBalance, ct);

        if (summary is null)
            return Result.Success(new SupplierAnalyticsSummaryResponse(0, 0, 0, totalOutstanding));

        var average = summary.Count > 0 ? summary.Total / summary.Count : 0;
        return Result.Success(new SupplierAnalyticsSummaryResponse(summary.Total, summary.Count, average, totalOutstanding));
    }

    public async Task<Result<List<TopSupplierResponse>>> GetTopSuppliersAsync(AnalyticsRangeFilter filter, CancellationToken ct = default)
    {
        var grouped = await FilteredPurchaseInvoices(filter)
            .GroupBy(i => new { i.SupplierId, SupplierName = i.Supplier!.Name })
            .Select(g => new
            {
                g.Key.SupplierId,
                g.Key.SupplierName,
                Total = g.Sum(i => i.TotalAmount),
                Count = g.Count()
            })
            .OrderByDescending(x => x.Total)
            .Take(filter.Limit)
            .ToListAsync(ct);

        var result = grouped
            .Select(x => new TopSupplierResponse(x.SupplierId, x.SupplierName, x.Total, x.Count))
            .ToList();

        return Result.Success(result);
    }

    public async Task<Result<List<PurchaseTrendPointResponse>>> GetPurchaseTrendAsync(AnalyticsRangeFilter filter, CancellationToken ct = default)
    {
        var grouped = await FilteredPurchaseInvoices(filter)
            .GroupBy(i => i.InvoiceDate.Date)
            .Select(g => new
            {
                Date = g.Key,
                Amount = g.Sum(i => i.TotalAmount),
                Count = g.Count()
            })
            .OrderBy(x => x.Date)
            .ToListAsync(ct);

        var result = grouped
            .Select(x => new PurchaseTrendPointResponse(x.Date, x.Amount, x.Count))
            .ToList();

        return Result.Success(result);
    }

    public async Task<Result<MaintenanceAnalyticsSummaryResponse>> GetMaintenanceSummaryAsync(AnalyticsRangeFilter filter, CancellationToken ct = default)
    {
        var summary = await _dbContext.MaintenanceDevices
            .Where(m => !m.IsDeleted)
            .Where(m => filter.StartDate == null || m.CreatedAt >= filter.StartDate)
            .Where(m => filter.EndDate == null || m.CreatedAt <= filter.EndDate)
            .GroupBy(_ => 1)
            .Select(g => new
            {
                Count = g.Count(),
                Revenue = g.Sum(m => m.TotalPrice),
                Cost = g.Sum(m => m.TotalCost),
                Pending = g.Count(m => m.Status == MaintenanceStatus.Pending),
                Delivered = g.Count(m => m.Status == MaintenanceStatus.Delivered),
                Returned = g.Count(m => m.Status == MaintenanceStatus.Returned)
            })
            .FirstOrDefaultAsync(ct);

        if (summary is null)
            return Result.Success(new MaintenanceAnalyticsSummaryResponse(0, 0, 0, 0, 0, 0, 0));

        var average = summary.Count > 0 ? summary.Revenue / summary.Count : 0;
        return Result.Success(new MaintenanceAnalyticsSummaryResponse(
            summary.Revenue, summary.Revenue - summary.Cost, summary.Count, average,
            summary.Pending, summary.Delivered, summary.Returned));
    }

    public async Task<Result<InventoryAnalyticsSummaryResponse>> GetInventorySummaryAsync(CancellationToken ct = default)
    {
        // لقطة حالية للمخزون - مالها معنى "فترة زمنية"، عكس باقي شاشات التحليلات.
        var products = _dbContext.Products.Where(p => !p.IsDeleted);

        var summary = await products
            .GroupBy(_ => 1)
            .Select(g => new
            {
                Count = g.Count(),
                LowStock = g.Count(p => p.Quantity > 0 && p.Quantity <= p.MinQuantityAlert),
                OutOfStock = g.Count(p => p.Quantity <= 0)
            })
            .FirstOrDefaultAsync(ct);

        var inventoryValue = await _dbContext.ProductBatches
            .Where(b => !b.IsDeleted)
            .SumAsync(b => b.AvailableQuantity * b.PurchasePrice, ct);

        if (summary is null)
            return Result.Success(new InventoryAnalyticsSummaryResponse(inventoryValue, 0, 0, 0));

        return Result.Success(new InventoryAnalyticsSummaryResponse(inventoryValue, summary.Count, summary.LowStock, summary.OutOfStock));
    }

    public async Task<Result<List<SlowMovingProductResponse>>> GetSlowMovingProductsAsync(AnalyticsRangeFilter filter, CancellationToken ct = default)
    {
        // منتجات بمخزون متاح لكنها باعت قليل أو منعدم خلال الفترة - مؤشر بضاعة راكدة.
        var soldQtyByProduct = await FilteredInvoices(filter)
            .SelectMany(i => i.Items)
            .GroupBy(x => x.ProductId)
            .Select(g => new { ProductId = g.Key, Qty = g.Sum(x => x.Quantity) })
            .ToDictionaryAsync(x => x.ProductId, x => x.Qty, ct);

        var products = await _dbContext.Products
            .Where(p => !p.IsDeleted && p.Quantity > 0)
            .Select(p => new { p.Id, p.Name, p.Quantity })
            .ToListAsync(ct);

        var result = products
            .Select(p => new SlowMovingProductResponse(
                p.Id,
                p.Name ?? "",
                p.Quantity,
                soldQtyByProduct.TryGetValue(p.Id, out var qty) ? qty : 0))
            .OrderBy(x => x.QuantitySoldInPeriod)
            .ThenByDescending(x => x.QuantityInStock)
            .Take(filter.Limit)
            .ToList();

        return Result.Success(result);
    }

    public async Task<Result<FinanceAnalyticsSummaryResponse>> GetFinanceSummaryAsync(AnalyticsRangeFilter filter, CancellationToken ct = default)
    {
        var summary = await _dbContext.DrawerTransactions
            .Where(t => !t.IsDeleted)
            .Where(t => filter.StartDate == null || t.CreatedAt >= filter.StartDate)
            .Where(t => filter.EndDate == null || t.CreatedAt <= filter.EndDate)
            .GroupBy(_ => 1)
            .Select(g => new
            {
                Income = g.Where(t => t.Type == DrawerTransactionType.Income).Sum(t => t.Amount),
                Expense = g.Where(t => t.Type == DrawerTransactionType.Expense).Sum(t => t.Amount)
            })
            .FirstOrDefaultAsync(ct);

        var income = summary?.Income ?? 0;
        var expense = summary?.Expense ?? 0;
        return Result.Success(new FinanceAnalyticsSummaryResponse(income, expense, income - expense));
    }

    public async Task<Result<List<ExpenseCategoryBreakdownResponse>>> GetExpenseBreakdownAsync(AnalyticsRangeFilter filter, CancellationToken ct = default)
    {
        var grouped = await _dbContext.DrawerTransactions
            .Where(t => !t.IsDeleted)
            .Where(t => t.Type == DrawerTransactionType.Expense)
            .Where(t => filter.StartDate == null || t.CreatedAt >= filter.StartDate)
            .Where(t => filter.EndDate == null || t.CreatedAt <= filter.EndDate)
            .GroupBy(t => t.Category)
            .Select(g => new
            {
                Category = g.Key,
                Total = g.Sum(t => t.Amount),
                Count = g.Count()
            })
            .OrderByDescending(x => x.Total)
            .ToListAsync(ct);

        var result = grouped
            .Select(x => new ExpenseCategoryBreakdownResponse(GetCategoryLabel(x.Category), x.Total, x.Count))
            .ToList();

        return Result.Success(result);
    }

    private static string GetCategoryLabel(DrawerTransactionCategory category) => category switch
    {
        DrawerTransactionCategory.Sales => "مبيعات",
        DrawerTransactionCategory.Suppliers => "سداد موردين",
        DrawerTransactionCategory.Maintenance => "صيانة",
        DrawerTransactionCategory.Returns => "مرتجعات مبيعات",
        DrawerTransactionCategory.CustomerDebt => "تحصيل ديون عملاء",
        DrawerTransactionCategory.Operational => "حركة يدوية",
        DrawerTransactionCategory.Purchases => "مشتريات نقدية",
        DrawerTransactionCategory.SupplierReturn => "مرتجع لمورد",
        DrawerTransactionCategory.Expense => "مصروفات عامة",
        DrawerTransactionCategory.WalletOperation => "عمليات المحافظ",
        _ => "أخرى"
    };
}
