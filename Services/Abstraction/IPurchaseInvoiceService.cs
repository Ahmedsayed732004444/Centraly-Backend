using Centraly.Api.Abstractions;
using Centraly.Api.Contracts.Common;
using Centraly.Api.Contracts.Suppliers;

namespace Centraly.Api.Services.Abstraction;

public interface IPurchaseInvoiceService
{
    Task<Result<PurchaseInvoiceResponse>> AddPurchaseInvoiceAsync(CreatePurchaseInvoiceRequest request, string? userId, CancellationToken ct = default);
    Task<Result<PurchaseInvoiceResponse>> GetPurchaseInvoiceAsync(string id, CancellationToken ct = default);
    Task<Result<PaginatedList<PurchaseInvoiceResponse>>> GetAllPurchaseInvoicesAsync(RequestFilters filters, CancellationToken ct = default);
}