namespace Centraly.Api.Contracts.Finance;

using Centraly.Api.Contracts.Shared;

public record FinanceFilters : PaginationFilter
{
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
}
