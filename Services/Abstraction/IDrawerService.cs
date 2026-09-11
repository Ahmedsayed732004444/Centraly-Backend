namespace Centraly.Api.Services.Abstraction;

public interface IDrawerService
{
    Task<Result<DrawerSessionResponse>> OpenSessionAsync(OpenSessionRequest request, string userId, CancellationToken ct = default);
    Task<Result<DrawerSessionResponse>> CloseSessionAsync(int type, string userId, CancellationToken ct = default);
    Task<Result<DrawerTransactionResponse>> RecordTransactionAsync(DrawerTransactionCategory category, DrawerTransactionType type, decimal amount, decimal profit, string? notes, string? source, string userId, CancellationToken ct = default);
    Task<Result<DrawerTransactionResponse>> AddManualTransactionAsync(AddManualTransactionRequest request, string userId, CancellationToken ct = default);
    Task<Result<DrawerSessionResponse>> GetActiveSessionAsync(int type = 1, CancellationToken ct = default);
    Task<Result<DrawerSessionResponse>> GetSessionByIdAsync(string id, CancellationToken ct = default);

    /// <summary>
    /// Session history. Pass <paramref name="type"/> to see only one shift's history
    /// (e.g. 2 = Maintenance) - omit it to see every shift type mixed together.
    /// </summary>
    Task<Result<PaginatedList<DrawerSessionResponse>>> GetSessionsHistoryAsync(RequestFilters filters, int? type = null, CancellationToken ct = default);
}