namespace Centraly.Api.Services.Implementation;

public class TransactionRouterService(
    IFinancePolicyService policyService,
    IDrawerService drawerService,
    ISafeService safeService) : ITransactionRouterService
{
    private readonly IFinancePolicyService _policyService = policyService;
    private readonly IDrawerService _drawerService = drawerService;
    private readonly ISafeService _safeService = safeService;

    public async Task<Result<(string Id, PaymentSource Source)>> RouteTransactionAsync(
        GlobalTransactionCategory category, decimal amount, decimal profit, PaymentSource? requestedSource,
        string? notes, string? referenceId, string userId, CancellationToken ct = default)
    {
        var policyResult = await _policyService.GetPolicyForCategoryAsync(category, ct);
        if (policyResult.IsFailure)
            return Result.Failure<(string Id, PaymentSource Source)>(policyResult.Error);

        var policy = policyResult.Value;
        PaymentSource effectiveSource;

        switch (policy)
        {
            case PaymentSourcePolicy.DrawerOnly:
                if (requestedSource == PaymentSource.Safe)
                    return Result.Failure<(string Id, PaymentSource Source)>(TransactionRouterErrors.PolicyViolation);
                effectiveSource = PaymentSource.Drawer;
                break;

            case PaymentSourcePolicy.SafeOnly:
                if (requestedSource == PaymentSource.Drawer)
                    return Result.Failure<(string Id, PaymentSource Source)>(TransactionRouterErrors.PolicyViolation);
                effectiveSource = PaymentSource.Safe;
                break;

            default: // Either
                if (requestedSource is null)
                    return Result.Failure<(string Id, PaymentSource Source)>(TransactionRouterErrors.PolicyViolation);
                effectiveSource = requestedSource.Value;
                break;
        }

        var drawerType = MapToTransactionType(category);

        if (effectiveSource == PaymentSource.Drawer)
        {
            var drawerCategory = MapToDrawerCategory(category);
            var result = await _drawerService.RecordTransactionAsync(drawerCategory, drawerType, amount, profit, notes, referenceId, userId, ct);
            return result.IsSuccess ? Result.Success((result.Value.Id, PaymentSource.Drawer)) : Result.Failure<(string Id, PaymentSource Source)>(result.Error);
        }

        var safeCategory = MapToSafeCategory(category);
        var mainSafeResult = await _safeService.GetMainSafeAsync(ct);
        if (mainSafeResult.IsFailure)
            return Result.Failure<(string Id, PaymentSource Source)>(mainSafeResult.Error);

        var safeResult = await _safeService.AddManualTransactionAsync(mainSafeResult.Value.Id, drawerType, safeCategory, amount, profit, notes, userId, ct);
        return safeResult.IsSuccess ? Result.Success((safeResult.Value.Id, PaymentSource.Safe)) : Result.Failure<(string Id, PaymentSource Source)>(safeResult.Error);
    }

    private static DrawerTransactionCategory MapToDrawerCategory(GlobalTransactionCategory cat) => cat switch
    {
        GlobalTransactionCategory.CashSale => DrawerTransactionCategory.Sales,
        GlobalTransactionCategory.SalesReturn => DrawerTransactionCategory.Returns,
        GlobalTransactionCategory.CashPurchase => DrawerTransactionCategory.Purchases,
        GlobalTransactionCategory.PurchaseReturn => DrawerTransactionCategory.SupplierReturn,
        GlobalTransactionCategory.SupplierPayment => DrawerTransactionCategory.Suppliers,
        GlobalTransactionCategory.SupplierReceipt => DrawerTransactionCategory.Suppliers,
        GlobalTransactionCategory.CustomerPayment => DrawerTransactionCategory.CustomerDebt,
        GlobalTransactionCategory.CustomerRefund => DrawerTransactionCategory.Returns,
        GlobalTransactionCategory.Expense => DrawerTransactionCategory.Expense,
        GlobalTransactionCategory.ManualExpense => DrawerTransactionCategory.Expense,
        GlobalTransactionCategory.MaintenanceIncome => DrawerTransactionCategory.Maintenance,
        GlobalTransactionCategory.MaintenanceExpense => DrawerTransactionCategory.Maintenance,
        _ => DrawerTransactionCategory.Operational
    };

    private static SafeTransactionCategory MapToSafeCategory(GlobalTransactionCategory cat) => cat switch
    {
        GlobalTransactionCategory.Expense => SafeTransactionCategory.ExpensePayment,
        GlobalTransactionCategory.OwnerDeposit => SafeTransactionCategory.OwnerDeposit,
        GlobalTransactionCategory.OwnerWithdrawal => SafeTransactionCategory.OwnerWithdrawal,
        GlobalTransactionCategory.ManualIncome => SafeTransactionCategory.ManualDeposit,
        GlobalTransactionCategory.ManualExpense => SafeTransactionCategory.ManualWithdrawal,
        GlobalTransactionCategory.CashSale => SafeTransactionCategory.Sales,
        GlobalTransactionCategory.SalesReturn => SafeTransactionCategory.Returns,
        GlobalTransactionCategory.CashPurchase => SafeTransactionCategory.Purchases,
        GlobalTransactionCategory.PurchaseReturn => SafeTransactionCategory.SupplierReturn,
        GlobalTransactionCategory.SupplierPayment => SafeTransactionCategory.SupplierPayment,
        GlobalTransactionCategory.CustomerPayment => SafeTransactionCategory.CustomerPayment,
        GlobalTransactionCategory.MaintenanceIncome => SafeTransactionCategory.Maintenance,
        GlobalTransactionCategory.MaintenanceExpense => SafeTransactionCategory.Maintenance,
        _ => SafeTransactionCategory.General
    };

    private static DrawerTransactionType MapToTransactionType(GlobalTransactionCategory cat) => cat switch
    {
        GlobalTransactionCategory.CashSale => DrawerTransactionType.Income,
        GlobalTransactionCategory.CustomerPayment => DrawerTransactionType.Income,
        GlobalTransactionCategory.SupplierReceipt => DrawerTransactionType.Income,
        GlobalTransactionCategory.PurchaseReturn => DrawerTransactionType.Income,
        GlobalTransactionCategory.OwnerDeposit => DrawerTransactionType.Income,
        GlobalTransactionCategory.ManualIncome => DrawerTransactionType.Income,
        GlobalTransactionCategory.MaintenanceIncome => DrawerTransactionType.Income,
        _ => DrawerTransactionType.Expense // includes MaintenanceExpense
    };
}

