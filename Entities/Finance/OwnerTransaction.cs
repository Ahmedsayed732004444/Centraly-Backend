using Centraly.Api.Contracts.Shared.Enums;
using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Finance;

public class OwnerTransaction : BaseEntity
{
    public GlobalTransactionCategory Category { get; set; }
    public decimal Amount { get; set; }
    public PaymentSource PaymentSource { get; set; }
    public string? Notes { get; set; }
}
