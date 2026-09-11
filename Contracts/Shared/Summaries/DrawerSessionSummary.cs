namespace Centraly.Api.Contracts.Shared.Summaries;

public record DrawerSessionSummary(
    string   DrawerSessionId,
    DateTime OpenedAt,
    bool     IsClosed
);
