namespace Centraly.Api.Services.Implementation;

public partial class WalletService(
    ApplicationDbContext dbContext,
    IDrawerService drawerService,
    IWebHostEnvironment _env,
    IHttpContextAccessor _accessor) : IWalletService
{
    public async Task<Result<WalletResponse>> CreateWalletAsync(CreateWalletRequest request, string userId, CancellationToken ct = default)
    {
        var allowedOps = request.AllowedOperations is { Count: > 0 }
            ? request.AllowedOperations.Distinct().ToList()
            : [WalletOperationType.CashIn, WalletOperationType.CashOut];

        var wallet = new Wallet
        {
            Name = request.Name,
            PhoneNumber = request.PhoneNumber,
            OwnerName = request.OwnerName,
            Balance = request.InitialBalance,
            IsActive = true,
            AllowedOperations = allowedOps,
            CreatedByUserId = userId
        };

        // نفس المنطق: تحقق من الصورة الأول، وارفعها بعدين
        if (request.Image is not null)
            wallet.ImageUrl = await FileHelper.UploadeFileAsync(request.Image, "uploads/wallets", _env, _accessor);

        dbContext.Wallets.Add(wallet);

        if (request.InitialBalance > 0)
        {
            var transaction = new WalletTransaction
            {
                Wallet = wallet,
                Type = WalletTransactionType.Income,
                Amount = request.InitialBalance,
                BalanceAfter = request.InitialBalance,
                Notes = "Initial Balance",
                CreatedByUserId = userId
            };
            dbContext.WalletTransactions.Add(transaction);
        }

        await dbContext.SaveChangesAsync(ct);

        return Result.Success(new WalletResponse(
            wallet.Id,
            wallet.Name,
            wallet.PhoneNumber,
            wallet.OwnerName,
            wallet.Balance,
            wallet.ImageUrl,
            wallet.IsActive,
            wallet.AllowedOperations,
            wallet.CreatedAt));
    }

    public async Task<Result<WalletOperationResponse>> ProcessOperationAsync(ProcessOperationRequest request, string userId, CancellationToken ct = default)
    {
        var ownsTransaction = dbContext.Database.CurrentTransaction == null;
        var transaction = ownsTransaction ? await dbContext.Database.BeginTransactionAsync(ct) : null;
        try
        {
            var wallet = await dbContext.Wallets.FirstOrDefaultAsync(w => w.Id == request.WalletId, ct);
            if (wallet == null)
                return Result.Failure<WalletOperationResponse>(WalletErrors.NotFound);

            if (!wallet.IsActive)
                return Result.Failure<WalletOperationResponse>(WalletErrors.Inactive);

            if (!wallet.AllowedOperations.Contains(request.OperationType))
                return Result.Failure<WalletOperationResponse>(new Error("Wallet.OperationNotAllowed", "هذه العملية غير مفعلة في هذه المحفظة", 400));

            decimal profit = 0;
            WalletTransactionType walletTxType;
            DrawerTransactionType drawerTxType;

            if (request.OperationType == WalletOperationType.CashOut)
            {
                // CashOut (سحب من عميل): Wallet Income, Drawer Expense
                walletTxType = WalletTransactionType.Income;
                drawerTxType = DrawerTransactionType.Expense;
                profit = request.TransferredAmount - request.PhysicalCashAmount;

                wallet.Balance += request.TransferredAmount;
            }
            else if (request.OperationType == WalletOperationType.CashIn)
            {
                // CashIn (بيع / إيداع لعميل): Wallet Expense, Drawer Income
                if (wallet.Balance < request.TransferredAmount)
                    return Result.Failure<WalletOperationResponse>(new Error("Wallet.InsufficientBalance", "رصيد المحفظة لا يكفي لإتمام هذه العملية", 400));

                walletTxType = WalletTransactionType.Expense;
                drawerTxType = DrawerTransactionType.Income;
                profit = request.PhysicalCashAmount - request.TransferredAmount;

                wallet.Balance -= request.TransferredAmount;
            }
            else if (request.OperationType == WalletOperationType.Recharge)
            {
                // Recharge (شحن رصيد هوائي): Wallet Expense (TransferredAmount), Drawer Income (PhysicalCashAmount)
                if (wallet.Balance < request.TransferredAmount)
                    return Result.Failure<WalletOperationResponse>(new Error("Wallet.InsufficientBalance", "رصيد المحفظة لا يكفي لشحن هذا الرصيد", 400));

                walletTxType = WalletTransactionType.Expense;
                drawerTxType = DrawerTransactionType.Income;
                profit = request.PhysicalCashAmount - request.TransferredAmount;

                wallet.Balance -= request.TransferredAmount;
            }
            else
            {
                return Result.Failure<WalletOperationResponse>(new Error("Wallet.InvalidOperation", "نوع العملية غير صالح", 400));
            }

            // 1. Drawer Transaction
            var drawerResult = await drawerService.RecordTransactionAsync(
                (DrawerTransactionCategory)10, // WalletOperation
                drawerTxType,
                request.PhysicalCashAmount,
                profit,
                request.Notes ?? $"Wallet operation: {request.OperationType}",
                $"Wallet:{wallet.Name}",
                userId,
                ct);
            if (!drawerResult.IsSuccess)
                return Result.Failure<WalletOperationResponse>(drawerResult.Error);

            var drawerTxId = drawerResult.Value.Id;

            // 2. Wallet Transaction
            var walletTx = new WalletTransaction
            {
                WalletId = wallet.Id,
                Type = walletTxType,
                Amount = request.TransferredAmount,
                BalanceAfter = wallet.Balance,
                Notes = request.Notes,
                CreatedByUserId = userId
            };
            dbContext.WalletTransactions.Add(walletTx);

            // 3. Wallet Operation
            var operation = new WalletOperation
            {
                WalletId = wallet.Id,
                OperationType = request.OperationType,
                TransferredAmount = request.TransferredAmount,
                PhysicalCashAmount = request.PhysicalCashAmount,
                Profit = profit,
                DrawerTransactionId = drawerTxId,
                CreatedByUserId = userId
            };
            dbContext.WalletOperations.Add(operation);

            await dbContext.SaveChangesAsync(ct);
            if (ownsTransaction) await transaction.CommitAsync(ct);

            return Result.Success(new WalletOperationResponse(
                operation.Id,
                wallet.Id,
                operation.OperationType,
                operation.TransferredAmount,
                operation.PhysicalCashAmount,
                operation.Profit,
                operation.DrawerTransactionId,
                operation.CreatedAt));
        }
        catch
        {
            if (ownsTransaction) await transaction.RollbackAsync(ct);
            throw;
        }
        finally
        {
            if (ownsTransaction) await transaction.DisposeAsync();
        }
    }
}
