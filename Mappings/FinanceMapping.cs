namespace Centraly.Api.Mappings;

public static class FinanceMapping
{
    // ─────────────────────────────────────────────────────────────────
    //  Safes
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<SafeResponse> ProjectToResponse(this IQueryable<Safe> query)
    {
        return query
            .AsNoTracking()
            .Select(s => new SafeResponse(s.Id, s.Name, s.Balance, s.IsMain));
    }

    public static IQueryable<SafeTransactionResponse> ProjectToResponse(this IQueryable<SafeTransaction> query)
    {
        return query
            .AsNoTracking()
            .Select(t => new SafeTransactionResponse(
                t.Id, t.SafeId, t.TransactionType.ToString(), t.Category.ToString(), t.Amount, t.BalanceAfter, t.CreatedAt, t.Notes));
    }

    // ─────────────────────────────────────────────────────────────────
    //  Drawer
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<DrawerSessionResponse> ProjectToResponse(this IQueryable<DrawerSession> query)
    {
        return query
            .AsNoTracking()
            .Select(s => new DrawerSessionResponse(
                s.Id,
                (int)s.Type,
                s.OpeningBalance,
                s.OpenedAt,
                s.OpenedByUserId,
                s.IsClosed,
                s.ClosedAt,
                s.TotalIncome,
                s.TotalExpense,
                s.ClosingBalance, s.TotalProfit ?? s.Transactions.Sum(t => (decimal?)t.Profit), s.Transactions
                    .OrderByDescending(t => t.CreatedAt)
                    .Select(t => new DrawerTransactionResponse(
                        t.Id, t.Type, t.Category, t.Amount, t.Balance, t.Source, t.Notes, t.CreatedAt, t.UserId))
                    .ToList()));
    }

    public static IQueryable<DrawerSessionResponse> ProjectToSummaryResponse(this IQueryable<DrawerSession> query)
    {
        return query
            .AsNoTracking()
            .Select(s => new DrawerSessionResponse(
                s.Id, (int)s.Type, s.OpeningBalance, s.OpenedAt, s.OpenedByUserId, s.IsClosed, s.ClosedAt,
                s.TotalIncome, s.TotalExpense, s.ClosingBalance, s.TotalProfit ?? s.Transactions.Sum(t => (decimal?)t.Profit), new List<DrawerTransactionResponse>()));
    }

    // ─────────────────────────────────────────────────────────────────
    //  Expenses
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<ExpenseCategoryResponse> ProjectToResponse(this IQueryable<ExpenseCategory> query)
    {
        return query
            .AsNoTracking()
            .Select(c => new ExpenseCategoryResponse(c.Id, c.Name));
    }

    public static IQueryable<ExpenseResponse> ProjectToResponse(this IQueryable<Expense> query)
    {
        return query
            .AsNoTracking()
            .Select(e => new ExpenseResponse(
                e.Id, e.CategoryId, e.Category!.Name, e.Amount, e.PaymentSource.ToString(), e.ExpenseDate, e.Notes));
    }

    // ─────────────────────────────────────────────────────────────────
    //  Owner Transactions
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<OwnerTransactionResponse> ProjectToResponse(this IQueryable<OwnerTransaction> query)
    {
        return query
            .AsNoTracking()
            .Select(t => new OwnerTransactionResponse(
                t.Id, t.Category, t.Amount, t.PaymentSource, t.Notes, t.CreatedAt, t.CreatedByUserId));
    }

    public static OwnerTransactionResponse ToResponse(this OwnerTransaction t)
    {
        return new OwnerTransactionResponse(
            t.Id, t.Category, t.Amount, t.PaymentSource, t.Notes, t.CreatedAt, t.CreatedByUserId);
    }
}

