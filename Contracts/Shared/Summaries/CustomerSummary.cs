namespace Centraly.Api.Contracts.Shared.Summaries;

public record CustomerSummary(
    string  CustomerId,
    string? Name,
    string? Phone
);
