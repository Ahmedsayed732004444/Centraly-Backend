using Centraly.Api.Contracts.Shared.Enums;
using System;

namespace Centraly.Api.Entities.Finance;

public class TransactionSourcePolicy
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public GlobalTransactionCategory Category { get; set; }
    public PaymentSourcePolicy AllowedSource { get; set; }
    public DateTime UpdatedAt { get; set; }
}
