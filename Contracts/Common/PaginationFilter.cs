namespace Centraly.Api.Contracts.Common;

public record PaginationFilter
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
}
