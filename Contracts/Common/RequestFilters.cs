using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Common;
public enum SortDirection
{
    Asc,
    Desc
}

public record RequestFilters
{
    private const int MaxPageSize = 50;
    private int _pageSize = 10;

    public int PageNumber { get; init; } = 1;

    public int PageSize
    {
        get => _pageSize;
        init => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }

    public string? SearchValue { get; init; }
    public string? SortColumn { get; init; }
    public SortDirection SortDirection { get; init; } = SortDirection.Asc;

    // Filters for Inventory
    public string? CategoryId { get; init; }
    public string? DepartmentId { get; init; }
    public string? StockStatus { get; init; }
    public ProductUsageDto? Usage { get; init; }
    public ProductUsageDto? ExcludeUsage { get; init; }

    // Filters for Suppliers & Transactions
    public string? SupplierId { get; init; }
    public string? CustomerId { get; init; }
    public string? CustomerPhone { get; init; }
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public string? Status { get; init; }

    // Filters for Sales
    public SaleTypeDto? SaleType { get; init; }
    public PaymentMethodDto? PaymentMethod { get; init; }
}

