using Centraly.Api.Contracts.Maintenance;
using Centraly.Api.Entities.Maintenance;

namespace Centraly.Api.Services.Implementation;

public class MaintenanceService(
    ApplicationDbContext dbContext,
    ITransactionRouterService transactionRouter,
    ILogger<MaintenanceService> logger,
    INotificationService notificationService) : IMaintenanceService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    // Routed through ITransactionRouterService (not IDrawerService directly) so
    // maintenance cash movements respect the configured FinancePolicy for
    // MaintenanceIncome/MaintenanceExpense instead of always forcing the drawer.
    private readonly ITransactionRouterService _transactionRouter = transactionRouter;
    private readonly ILogger<MaintenanceService> _logger = logger;
    private readonly INotificationService _notificationService = notificationService;

    private static readonly string[] AllowedSortColumns = ["CreatedAt", "DeliveryDate", "TotalPrice"];

    // ─────────────────────────────────────────────────────────────────
    //  Create Maintenance Ticket
    // ─────────────────────────────────────────────────────────────────
    public async Task<Result<MaintenanceResponse>> CreateMaintenanceAsync(
        CreateMaintenanceRequest request, string userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var device = new MaintenanceDevice
            {
                CustomerName = request.CustomerName,
                CustomerPhone = request.CustomerPhone,
                CustomerId = string.IsNullOrWhiteSpace(request.CustomerId) ? null : request.CustomerId,
                DeviceDescription = request.DeviceDescription,
                Problem = request.Problem,
                PaidAmount = request.PaidAmount,
                DeliveryDate = request.DeliveryDate,
                Status = MaintenanceStatus.Pending,
                CreatedByUserId = userId
            };

            _dbContext.MaintenanceDevices.Add(device);
            await _dbContext.SaveChangesAsync(ct);

            if (request.PaidAmount > 0)
            {
                var routeResult = await _transactionRouter.RouteTransactionAsync(
                    GlobalTransactionCategory.MaintenanceIncome,
                    request.PaidAmount,
                    0, // profit - service/parts price isn't set until UpdateMaintenanceAsync
                    requestedSource: null,
                    $"مقدم صيانة - العميل: {device.CustomerName}",
                    device.Id,
                    userId,
                    ct);

                if (routeResult.IsFailure)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<MaintenanceResponse>(routeResult.Error);
                }
            }

            await transaction.CommitAsync(ct);
            return Result.Success(MapToResponse(device));
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error creating maintenance ticket");
            return Result.Failure<MaintenanceResponse>(MaintenanceErrors.CreationFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Update Maintenance Ticket
    // ─────────────────────────────────────────────────────────────────
    // NOTE - root cause (confirmed from SQL logs): this app has a global soft-delete
    // interceptor (ApplicationDbContext.ApplyAuditAndSoftDelete) that converts every
    // EntityState.Deleted entry into EntityState.Modified + IsDeleted = true, so
    // Remove()/RemoveRange() never issues a real SQL DELETE for any BaseEntity.
    //
    // The problem: before that interceptor runs, EF has already performed its normal
    // relationship fixup for a dependent being removed from a REQUIRED collection
    // navigation - it nulls the dependent's FK in memory, on the assumption the row
    // is about to be deleted for real. Since the row is actually only soft-deleted
    // (an UPDATE, not a DELETE), that null FK gets sent to the database and is
    // rejected because MaintenanceDeviceId is NOT NULL.
    //
    // Fix: never call Remove()/RemoveRange() on MaintenanceProductItem here. Soft-
    // delete it by hand (IsDeleted/DeletedAt as plain property assignments) so EF's
    // change tracker only ever sees a partial UPDATE of those two columns, and the
    // FK is never touched. The existing global query filter (WHERE IsDeleted = 0)
    // already keeps these rows out of every other query.
    //
    // Product items are also reconciled (matched by ProductId) instead of being
    // deleted-and-recreated wholesale: unchanged items are left completely alone,
    // matched items just get their Quantity/MaintenancePrice updated, removed items
    // are soft-deleted as above, and only genuinely new items are inserted.

    public async Task<Result<MaintenanceResponse>> UpdateMaintenanceAsync(
        string id, UpdateMaintenanceRequest request, string userId, CancellationToken ct = default)
    {
        var device = await _dbContext.MaintenanceDevices
            .Include(m => m.ProductsUsed)
            .FirstOrDefaultAsync(m => m.Id == id, ct);

        if (device is null)
            return Result.Failure<MaintenanceResponse>(MaintenanceErrors.NotFound);

        if (device.Status != MaintenanceStatus.Pending)
            return Result.Failure<MaintenanceResponse>(MaintenanceErrors.InvalidStatus);

        // Reconciliation assumes one row per product per ticket.
        var requestedProductIds = request.ProductsUsed.Select(p => p.ProductId).ToList();
        if (requestedProductIds.Distinct().Count() != requestedProductIds.Count)
            return Result.Failure<MaintenanceResponse>(MaintenanceErrors.DuplicateProduct);

        if (requestedProductIds.Count > 0)
        {
            var existingProductCount = await _dbContext.Products
                .CountAsync(p => requestedProductIds.Contains(p.Id) && !p.IsDeleted, ct);

            if (existingProductCount != requestedProductIds.Count)
                return Result.Failure<MaintenanceResponse>(MaintenanceErrors.ProductNotFound);
        }

        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            device.CustomerName = request.CustomerName;
            device.CustomerPhone = request.CustomerPhone;
            device.CustomerId = string.IsNullOrWhiteSpace(request.CustomerId) ? null : request.CustomerId;
            device.DeviceDescription = request.DeviceDescription;
            device.Problem = request.Problem;
            device.Solution = request.Solution;
            device.ServicePrice = request.ServicePrice;
            device.DeliveryDate = request.DeliveryDate;
            device.PaidAmount = request.PaidAmount;
            device.UpdatedAt = DateTime.UtcNow;
            device.UpdatedByUserId = userId;

            var existingItemsByProductId = device.ProductsUsed.ToDictionary(i => i.ProductId);
            var requestedByProductId = request.ProductsUsed.ToDictionary(p => p.ProductId);

            // 1) Items that existed before but aren't in the new list anymore ->
            // soft-delete by hand. Do NOT call Remove()/RemoveRange() and do NOT
            // touch device.ProductsUsed - see the note above on why that nulls the
            // required MaintenanceDeviceId FK via EF's relationship fixup.
            var itemsToRemove = device.ProductsUsed
                .Where(i => !requestedByProductId.ContainsKey(i.ProductId))
                .ToList();

            foreach (var item in itemsToRemove)
            {
                item.IsDeleted = true;
                item.DeletedAt = DateTime.UtcNow;
                item.UpdatedAt = DateTime.UtcNow;
                item.UpdatedByUserId = userId;
            }

            // 2) Items present in both -> update in place (no FK touched at all).
            foreach (var requested in request.ProductsUsed)
            {
                if (existingItemsByProductId.TryGetValue(requested.ProductId, out var existing))
                {
                    existing.Quantity = requested.Quantity;
                    existing.MaintenancePrice = requested.MaintenancePrice;
                    existing.UpdatedAt = DateTime.UtcNow;
                    existing.UpdatedByUserId = userId;
                }
            }

            // 3) Items only in the new list -> insert as new rows.
            var newItems = request.ProductsUsed
                .Where(p => !existingItemsByProductId.ContainsKey(p.ProductId))
                .Select(p => new MaintenanceProductItem
                {
                    MaintenanceDeviceId = device.Id,
                    MaintenanceDevice = device,
                    ProductId = p.ProductId,
                    Quantity = p.Quantity,
                    MaintenancePrice = p.MaintenancePrice,
                    CreatedByUserId = userId
                })
                .ToList();

            if (newItems.Count > 0)
            {
                _dbContext.MaintenanceProductItems.AddRange(newItems);
            }

            device.TotalPartsPrice = request.ProductsUsed.Sum(p => p.MaintenancePrice * p.Quantity);
            device.TotalPrice = device.ServicePrice + device.TotalPartsPrice;

            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            return await GetByIdAsync(device.Id, ct);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error updating maintenance ticket {MaintenanceId}", id);
            return Result.Failure<MaintenanceResponse>(MaintenanceErrors.UpdateFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Deliver Maintenance Ticket
    // ─────────────────────────────────────────────────────────────────
    public async Task<Result<MaintenanceResponse>> DeliverMaintenanceAsync(
        string id, string userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var device = await _dbContext.MaintenanceDevices
                .Include(m => m.ProductsUsed)
                    .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id, ct);

            if (device is null)
                return Result.Failure<MaintenanceResponse>(MaintenanceErrors.NotFound);

            if (device.Status != MaintenanceStatus.Pending)
                return Result.Failure<MaintenanceResponse>(MaintenanceErrors.AlreadyDelivered);

            decimal totalCost = 0;

            foreach (var item in device.ProductsUsed)
            {
                var batches = await _dbContext.ProductBatches
                    .Where(b => b.ProductId == item.ProductId && b.AvailableQuantity > 0)
                    .OrderBy(b => b.CreatedAt)
                    .ToListAsync(ct);

                var remaining = item.Quantity;
                decimal itemCost = 0;

                foreach (var batch in batches)
                {
                    if (remaining <= 0) break;

                    var toDeduct = Math.Min(remaining, batch.AvailableQuantity);
                    batch.AvailableQuantity -= toDeduct;
                    batch.UpdatedAt = DateTime.UtcNow;
                    itemCost += toDeduct * batch.PurchasePrice;
                    remaining -= toDeduct;
                }

                if (remaining > 0)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<MaintenanceResponse>(MaintenanceErrors.InsufficientStock(item.Product?.Name ?? item.ProductId));
                }

                if (item.Product is not null)
                {
                    var qtyBeforeUsage = item.Product.Quantity;
                    item.Product.Quantity -= item.Quantity;
                    item.Product.UpdatedAt = DateTime.UtcNow;
                    await _notificationService.NotifyStockChangeAsync(item.Product, qtyBeforeUsage, ct);
                }

                item.CostPrice = item.Quantity > 0 ? itemCost / item.Quantity : 0;
                totalCost += itemCost;
            }

            device.TotalCost = totalCost;
            device.Status = MaintenanceStatus.Delivered;
            device.UpdatedAt = DateTime.UtcNow;
            device.UpdatedByUserId = userId;

            decimal profit = device.TotalPrice - totalCost;
            var remainingAmount = device.TotalPrice - device.PaidAmount;

            Result<(string Id, PaymentSource Source)> routeResult;
            if (remainingAmount >= 0)
            {
                routeResult = await _transactionRouter.RouteTransactionAsync(
                    GlobalTransactionCategory.MaintenanceIncome,
                    remainingAmount,
                    profit,
                    requestedSource: null,
                    $"تسليم صيانة - العميل: {device.CustomerName}",
                    device.Id,
                    userId,
                    ct);
            }
            else
            {
                routeResult = await _transactionRouter.RouteTransactionAsync(
                    GlobalTransactionCategory.MaintenanceExpense,
                    Math.Abs(remainingAmount),
                    profit,
                    requestedSource: null,
                    $"رد فرق تسليم صيانة - العميل: {device.CustomerName}",
                    device.Id,
                    userId,
                    ct);
            }

            if (routeResult.IsFailure)
            {
                await transaction.RollbackAsync(ct);
                return Result.Failure<MaintenanceResponse>(routeResult.Error);
            }

            if (routeResult.Value.Source == PaymentSource.Drawer)
                device.DrawerTransactionId = routeResult.Value.Id;

            device.PaidAmount = device.TotalPrice;

            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            return Result.Success(MapToResponse(device));
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error delivering maintenance ticket {Id}", id);
            return Result.Failure<MaintenanceResponse>(MaintenanceErrors.DeliveryFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Return Maintenance Ticket (before repair - no parts were consumed yet)
    // ─────────────────────────────────────────────────────────────────
    public async Task<Result<MaintenanceResponse>> ReturnMaintenanceAsync(
        string id, string userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var device = await _dbContext.MaintenanceDevices.FirstOrDefaultAsync(m => m.Id == id, ct);

            if (device is null)
                return Result.Failure<MaintenanceResponse>(MaintenanceErrors.NotFound);

            if (device.Status != MaintenanceStatus.Pending)
                return Result.Failure<MaintenanceResponse>(MaintenanceErrors.NotPending);

            device.Status = MaintenanceStatus.Returned;
            device.UpdatedAt = DateTime.UtcNow;
            device.UpdatedByUserId = userId;

            if (device.PaidAmount > 0)
            {
                var routeResult = await _transactionRouter.RouteTransactionAsync(
                    GlobalTransactionCategory.MaintenanceExpense,
                    device.PaidAmount,
                    0,
                    requestedSource: null,
                    $"رد مقدم صيانة (إرجاع بدون إصلاح) - العميل: {device.CustomerName}",
                    device.Id,
                    userId,
                    ct);

                if (routeResult.IsFailure)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<MaintenanceResponse>(routeResult.Error);
                }

                device.PaidAmount = 0;
            }

            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            return Result.Success(MapToResponse(device));
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error returning maintenance ticket {Id}", id);
            return Result.Failure<MaintenanceResponse>(MaintenanceErrors.ReturnFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get All (paginated, searchable, sortable)
    // ─────────────────────────────────────────────────────────────────
    public async Task<Result<PaginatedList<MaintenanceSummary>>> GetAllMaintenanceAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.MaintenanceDevices.AsQueryable();

            if (!string.IsNullOrEmpty(filters.Status) && Enum.TryParse<MaintenanceStatus>(filters.Status, true, out var statusEnum))
            {
                query = query.Where(m => m.Status == statusEnum);
            }

            if (filters.StartDate.HasValue)
                query = query.Where(m => m.CreatedAt >= filters.StartDate.Value);
            
            if (filters.EndDate.HasValue)
                query = query.Where(m => m.CreatedAt <= filters.EndDate.Value);

            query = query.ApplyFilters(filters,
                    searchPredicate: x => x.CustomerName.Contains(filters.SearchValue!) ||
                                          (x.CustomerPhone != null && x.CustomerPhone.Contains(filters.SearchValue!)),
                    allowedSortColumns: AllowedSortColumns);

            if (string.IsNullOrWhiteSpace(filters.SortColumn))
                query = query.OrderByDescending(m => m.CreatedAt);

            var mappedQuery = query
                .Select(m => new MaintenanceSummary(
                    m.Id, m.CustomerName, m.CustomerPhone, m.DeviceDescription, m.Problem,
                    m.TotalPrice, m.PaidAmount, m.RemainingAmount, m.DeliveryDate, m.Status.ToString(), m.CreatedAt))
                .AsNoTracking();

            var result = await mappedQuery.ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for maintenance tickets");
            return Result.Failure<PaginatedList<MaintenanceSummary>>(MaintenanceErrors.InvalidSortColumn);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get By Id (selection loading - no Include)
    // ─────────────────────────────────────────────────────────────────
    public async Task<Result<MaintenanceResponse>> GetByIdAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.MaintenanceDevices
            .Where(m => m.Id == id)
            .Select(m => new MaintenanceResponse(
                m.Id, m.CustomerName, m.CustomerPhone, m.CustomerId, m.DeviceDescription, m.Problem, m.Solution,
                m.ServicePrice, m.TotalPartsPrice, m.TotalPrice, m.TotalCost, m.PaidAmount, m.RemainingAmount,
                m.DeliveryDate, m.Status.ToString(),
                m.ProductsUsed.Select(p => new MaintenanceProductItemDto(
                    p.ProductId, p.Product != null ? p.Product.Name ?? string.Empty : string.Empty,
                    p.Quantity, p.MaintenancePrice, p.CostPrice))
                    .ToList(),
                m.CreatedAt))
            .AsNoTracking()
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<MaintenanceResponse>(MaintenanceErrors.NotFound)
            : Result.Success(response);
    }

    private static MaintenanceResponse MapToResponse(MaintenanceDevice m) => new(
        m.Id, m.CustomerName, m.CustomerPhone, m.CustomerId, m.DeviceDescription, m.Problem, m.Solution,
        m.ServicePrice, m.TotalPartsPrice, m.TotalPrice, m.TotalCost, m.PaidAmount, m.RemainingAmount,
        m.DeliveryDate, m.Status.ToString(),
        m.ProductsUsed.Select(p => new MaintenanceProductItemDto(
            p.ProductId, p.Product?.Name ?? string.Empty, p.Quantity, p.MaintenancePrice, p.CostPrice)).ToList(),
        m.CreatedAt);
}
