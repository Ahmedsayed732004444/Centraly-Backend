using System;
using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Finance;

public record CreateSafeRequest(string Name, bool IsMain, decimal InitialBalance);
public record SafeDepositRequest(decimal Amount, string? Notes, string? Source);
public record SafeWithdrawalRequest(decimal Amount, string? Notes, string? Reason);
public record ReceiveDrawerDepositRequest(string DrawerSessionId, decimal Amount, string? Notes);

public record SafeResponse(string Id, string Name, decimal Balance, bool IsMain);
public record SafeTransactionResponse(string Id, string SafeId, string TransactionType, string Category, decimal Amount, decimal BalanceAfter, DateTime CreatedAt, string? Notes);

public record CreateExpenseCategoryRequest(string Name);
public record CreateExpenseRequest(string CategoryId, decimal Amount, PaymentSource? PaymentSource, string? Notes);

public record ExpenseCategoryResponse(string Id, string Name);
public record ExpenseResponse(string Id, string CategoryId, string CategoryName, decimal Amount, string PaymentSource, DateTime ExpenseDate, string? Notes);

public record UpdateTransactionPolicyRequest(PaymentSourcePolicy AllowedSource);
public record TransactionPolicyResponse(string Id, string Category, string AllowedSource);
