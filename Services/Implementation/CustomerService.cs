using Centraly.Api.Mappings;

namespace Centraly.Api.Services.Implementation;

public class CustomerService(ApplicationDbContext dbContext, ILogger<CustomerService> logger) : ICustomerService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<CustomerService> _logger = logger;

    private static readonly string[] AllowedCustomerSortColumns = ["Name", "CreatedAt", "DebtBalance"];

    // ════════════════════════════════════════════════════════════════
    //  Add Customer
    // ════════════════════════════════════════════════════════════════

    public async Task<Result<CustomerResponse>> AddCustomerAsync(
        CreateCustomerRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var customer = new Customer
            {
                Name = request.Name,
                Phone = request.Phone,
                CreatedByUserId = userId
            };

            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync(ct);

            var response = new CustomerResponse(
                customer.Id, customer.Name, customer.Phone, customer.DebtBalance, 0, customer.CreatedAt);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating customer for user {UserId}", userId);
            return Result.Failure<CustomerResponse>(CustomerErrors.CreationFailed);
        }
    }

    // ════════════════════════════════════════════════════════════════
    //  Get Customer By Id
    // ════════════════════════════════════════════════════════════════

    public async Task<Result<CustomerResponse>> GetCustomerAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.Customers
            .Where(c => c.Id == id)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<CustomerResponse>(CustomerErrors.CustomerNotFound)
            : Result.Success(response);
    }

    // ════════════════════════════════════════════════════════════════
    //  Get All Customers
    // ════════════════════════════════════════════════════════════════

    public async Task<Result<PaginatedList<CustomerResponse>>> GetAllCustomersAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.Customers
                .Where(c => !c.IsDeleted)
                .ApplyFilters(filters,
                    searchPredicate: x =>
                        (x.Name != null && x.Name.Contains(filters.SearchValue!)) ||
                        (x.Phone != null && x.Phone.Contains(filters.SearchValue!)),
                    allowedSortColumns: AllowedCustomerSortColumns);

            var result = await query.ProjectToResponse().ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for customers");
            return Result.Failure<PaginatedList<CustomerResponse>>(CustomerErrors.InvalidSortColumn);
        }
    }

    // ════════════════════════════════════════════════════════════════
    //  Get Customer With Debt History (كشف حساب)
    // ════════════════════════════════════════════════════════════════

    public async Task<Result<CustomerDebtHistoryResponse>> GetCustomerWithDebtHistoryAsync(
        string id, CancellationToken ct = default)
    {
        var customer = await _dbContext.Customers
            .Where(c => c.Id == id)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        if (customer is null)
            return Result.Failure<CustomerDebtHistoryResponse>(CustomerErrors.CustomerNotFound);

        var deferredInvoices = await _dbContext.Invoices
            .Where(i => i.CustomerId == id && i.PaymentMethod == PaymentMethod.Deferred)
            .ProjectToSummary()
            .OrderByDescending(i => i.CreatedAt)
            .ToListAsync(ct);

        var payments = await _dbContext.CustomerDebtPayments
            .Where(p => p.CustomerId == id)
            .ProjectToResponse()
            .OrderByDescending(p => p.PaymentDate)
            .ToListAsync(ct);

        var response = new CustomerDebtHistoryResponse(customer, deferredInvoices, payments);
        return Result.Success(response);
    }

    // ════════════════════════════════════════════════════════════════
    //  Update Customer
    // ════════════════════════════════════════════════════════════════

    public async Task<Result<CustomerResponse>> UpdateCustomerAsync(
        string id, UpdateCustomerRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var updated = await _dbContext.Customers
                .Where(c => c.Id == id && !c.IsDeleted)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(c => c.Name, request.Name)
                    .SetProperty(c => c.Phone, request.Phone)
                    .SetProperty(c => c.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(c => c.UpdatedByUserId, userId), ct);

            if (updated == 0)
                return Result.Failure<CustomerResponse>(CustomerErrors.CustomerNotFound);

            var response = await _dbContext.Customers
                .Where(c => c.Id == id)
                .ProjectToResponse()
                .FirstAsync(ct);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating customer {CustomerId}", id);
            return Result.Failure<CustomerResponse>(CustomerErrors.UpdateFailed);
        }
    }

    // ════════════════════════════════════════════════════════════════
    //  Soft Delete Customer
    // ════════════════════════════════════════════════════════════════
    // The debt-balance guard is folded into the ExecuteUpdateAsync predicate
    // itself, so the common (successful) path never fetches the entity.
    // A second lightweight query only runs to tell the two failure reasons
    // (not found vs. has debt) apart when the update affects 0 rows.

    public async Task<Result<bool>> DeleteCustomerAsync(string id, CancellationToken ct = default)
    {
        try
        {
            var deleted = await _dbContext.Customers
                .Where(c => c.Id == id && !c.IsDeleted && c.DebtBalance == 0)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(c => c.IsDeleted, true)
                    .SetProperty(c => c.DeletedAt, DateTime.UtcNow), ct);

            if (deleted > 0)
                return Result.Success(true);

            var exists = await _dbContext.Customers.AnyAsync(c => c.Id == id && !c.IsDeleted, ct);
            return Result.Failure<bool>(exists ? CustomerErrors.HasOutstandingDebt : CustomerErrors.CustomerNotFound);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting customer {CustomerId}", id);
            return Result.Failure<bool>(CustomerErrors.DeleteFailed);
        }
    }
}