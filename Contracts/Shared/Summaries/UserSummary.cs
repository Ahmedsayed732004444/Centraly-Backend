namespace Centraly.Api.Contracts.Shared.Summaries;

public record UserSummary(
    string  UserId,
    string  UserName,
    string? Email
);
