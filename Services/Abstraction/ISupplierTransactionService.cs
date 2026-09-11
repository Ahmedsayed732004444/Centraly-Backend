namespace Centraly.Api.Services.Abstraction;

public interface ISupplierTransactionService
{
    // Payments
    Task<Result<SupplierPaymentResponse>> AddPaymentAsync(CreateSupplierPaymentRequest request, string? userId, CancellationToken ct = default);
    Task<Result<SupplierPaymentResponse>> GetPaymentAsync(string id, CancellationToken ct = default);
    Task<Result<PaginatedList<SupplierPaymentResponse>>> GetAllPaymentsAsync(RequestFilters filters, CancellationToken ct = default);

    // Returns
    Task<Result<SupplierReturnResponse>> AddReturnAsync(CreateSupplierReturnRequest request, string? userId, CancellationToken ct = default);
    Task<Result<SupplierReturnResponse>> GetReturnAsync(string id, CancellationToken ct = default);
    Task<Result<PaginatedList<SupplierReturnResponse>>> GetAllReturnsAsync(RequestFilters filters, CancellationToken ct = default);
}