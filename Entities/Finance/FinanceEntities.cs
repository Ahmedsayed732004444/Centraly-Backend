using Centraly.Api.Entities.Common;
using System;
using System.Collections.Generic;
using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Entities.Finance;

public class Safe : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public bool IsMain { get; set; }
    public ICollection<SafeTransaction> Transactions { get; set; } = new List<SafeTransaction>();
}

public class SafeTransaction : BaseEntity
{
    public string SafeId { get; set; } = string.Empty;
    public Safe? Safe { get; set; }
    public DrawerTransactionType TransactionType { get; set; }
    public SafeTransactionCategory Category { get; set; }
    public decimal Amount { get; set; }
    public decimal Profit { get; set; }
    public decimal BalanceAfter { get; set; }
    public string? Notes { get; set; }
    public string? CreatedByUserId { get; set; }
}

public class ExpenseCategory : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}

public class Expense : BaseEntity
{
    public string CategoryId { get; set; } = string.Empty;
    public ExpenseCategory? Category { get; set; }
    public decimal Amount { get; set; }
    public decimal Profit { get; set; }
    public PaymentSource PaymentSource { get; set; }
    public string? SourceTransactionId { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string? Notes { get; set; }
    public string? CreatedByUserId { get; set; }
}

