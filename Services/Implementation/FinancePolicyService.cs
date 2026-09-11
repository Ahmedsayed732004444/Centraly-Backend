using Microsoft.Extensions.Caching.Hybrid;

namespace Centraly.Api.Services.Implementation;

public class FinancePolicyService(ApplicationDbContext dbContext, HybridCache hybridCache) : IFinancePolicyService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly HybridCache _hybridCache = hybridCache;

    // This list is read on essentially every checkout/payment (RouteTransactionAsync
    // resolves the policy for each category) and only changes when an admin edits it
    // from Settings - a strong HybridCache candidate, unlike the transactions it gates.
    private const string CachePrefix = "financePolicies";

    public async Task<Result<IEnumerable<TransactionPolicyResponse>>> GetPoliciesAsync(CancellationToken ct = default)
    {
        var policies = await _hybridCache.GetOrCreateAsync(
            $"{CachePrefix}-all",
            async ct => await _dbContext.TransactionSourcePolicies
                .AsNoTracking()
                .Select(p => new TransactionPolicyResponse(p.Id, p.Category.ToString(), p.AllowedSource.ToString()))
                .ToListAsync(ct),
            tags: [CachePrefix],
            cancellationToken: ct);

        return Result.Success<IEnumerable<TransactionPolicyResponse>>(policies);
    }

    public async Task<Result<TransactionPolicyResponse>> UpdatePolicyAsync(
        string categoryString, UpdateTransactionPolicyRequest request, CancellationToken ct = default)
    {
        if (!Enum.TryParse<GlobalTransactionCategory>(categoryString, out var category))
            return Result.Failure<TransactionPolicyResponse>(FinancePolicyErrors.InvalidCategory);

        var updated = await _dbContext.TransactionSourcePolicies
            .Where(p => p.Category == category)
            .ExecuteUpdateAsync(setters => setters.SetProperty(p => p.AllowedSource, request.AllowedSource), ct);

        if (updated == 0)
            return Result.Failure<TransactionPolicyResponse>(FinancePolicyErrors.PolicyNotFound);

        await _hybridCache.RemoveByTagAsync(CachePrefix, ct);

        var policy = await _dbContext.TransactionSourcePolicies
            .AsNoTracking()
            .Where(p => p.Category == category)
            .Select(p => new TransactionPolicyResponse(p.Id, p.Category.ToString(), p.AllowedSource.ToString()))
            .FirstAsync(ct);

        return Result.Success(policy);
    }

    // The hot path: RouteTransactionAsync calls this for every sale, purchase, payment
    // and expense in the system, so this - not the admin listing above - is where
    // caching actually earns its keep.
    public async Task<Result<PaymentSourcePolicy>> GetPolicyForCategoryAsync(
        GlobalTransactionCategory category, CancellationToken ct = default)
    {
        var allowedSource = await _hybridCache.GetOrCreateAsync(
            $"{CachePrefix}-{category}",
            async ct => await _dbContext.TransactionSourcePolicies
                .Where(p => p.Category == category)
                .Select(p => (PaymentSourcePolicy?)p.AllowedSource)
                .FirstOrDefaultAsync(ct),
            tags: [CachePrefix],
            cancellationToken: ct);

        return Result.Success(allowedSource ?? DefaultPolicyFor(category));
    }

    // Maintenance transactions used to always go straight to the drawer (they bypassed
    // this service entirely). Now that they're routed through it, an unconfigured policy
    // must still resolve to DrawerOnly so existing behavior is unchanged until an admin
    // explicitly opts a maintenance category into Safe/Either via UpdatePolicyAsync.
    // Everything else keeps the original "Either, don't fail the transaction" default.
    private static PaymentSourcePolicy DefaultPolicyFor(GlobalTransactionCategory category) => category switch
    {
        GlobalTransactionCategory.MaintenanceIncome => PaymentSourcePolicy.DrawerOnly,
        GlobalTransactionCategory.MaintenanceExpense => PaymentSourcePolicy.DrawerOnly,
        _ => PaymentSourcePolicy.Either
    };
}