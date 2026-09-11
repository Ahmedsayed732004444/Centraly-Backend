using Centraly.Api.Mappings;

namespace Centraly.Api.Services.Implementation;

public class SalesReturnService(
    ApplicationDbContext dbContext,
    IReturnProcessingService returnProcessor,
    ILogger<SalesReturnService> logger) : ISalesReturnService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly IReturnProcessingService _returnProcessor = returnProcessor;
    private readonly ILogger<SalesReturnService> _logger = logger;

    private static readonly string[] AllowedReturnSortColumns = ["ReturnDate", "TotalReturnedAmount"];

    // ─────────────────────────────────────────────────────────────────
    //  Add Return
    // ─────────────────────────────────────────────────────────────────
    // The actual workflow (validate invoice/items, restock batches, record
    // the return, route refund or adjust debt) lives in ReturnProcessingService
    // so it isn't duplicated between here and CustomerTransactionService.

    public Task<Result<ReturnRecordResponse>> AddReturnAsync(
        CreateCustomerReturnRequest request, string? userId, CancellationToken ct = default) =>
        _returnProcessor.ProcessReturnAsync(request, userId, expectedCustomerId: null, ct);

    // ─────────────────────────────────────────────────────────────────
    //  Get Return By Id
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<ReturnRecordResponse>> GetReturnAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.Returns
            .Where(r => r.Id == id)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<ReturnRecordResponse>(SalesReturnErrors.ReturnNotFound)
            : Result.Success(response);
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get All Returns
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<PaginatedList<ReturnRecordResponse>>> GetAllReturnsAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.Returns
                .Where(r => !r.IsDeleted)
                .Where(r => filters.StartDate == null || r.ReturnDate >= filters.StartDate)
                .Where(r => filters.EndDate == null || r.ReturnDate <= filters.EndDate)
                .ApplyFilters(filters,
                    searchPredicate: x => x.Invoice != null && x.Invoice.InvoiceNumber.Contains(filters.SearchValue!),
                    allowedSortColumns: AllowedReturnSortColumns);

            if (string.IsNullOrWhiteSpace(filters.SortColumn))
                query = query.OrderByDescending(r => r.ReturnDate);

            var mappedQuery = query.ProjectToSummaryResponse();

            var result = await mappedQuery.ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for sales returns");
            return Result.Failure<PaginatedList<ReturnRecordResponse>>(SalesReturnErrors.InvalidSortColumn);
        }
    }
}