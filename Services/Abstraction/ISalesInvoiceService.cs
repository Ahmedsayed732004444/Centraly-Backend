using Centraly.Api.Abstractions;
using Centraly.Api.Contracts.Common;
using Centraly.Api.Contracts.Sales;

namespace Centraly.Api.Services.Abstraction;

public interface ISalesInvoiceService
{
    Task<Result<SalesInvoiceResponse>> AddInvoiceAsync(CreateSalesInvoiceRequest request, string? userId, CancellationToken ct = default);
    Task<Result<SalesInvoiceResponse>> GetInvoiceAsync(string id, CancellationToken ct = default);
    Task<Result<PaginatedList<SalesInvoiceResponse>>> GetAllInvoicesAsync(RequestFilters filters, CancellationToken ct = default);
}
