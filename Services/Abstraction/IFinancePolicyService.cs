using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Centraly.Api.Contracts.Finance;
using Centraly.Api.Contracts.Shared.Enums;
using Centraly.Api.Abstractions;

namespace Centraly.Api.Services.Abstraction;

public interface IFinancePolicyService
{
    Task<Result<IEnumerable<TransactionPolicyResponse>>> GetPoliciesAsync(CancellationToken ct = default);
    Task<Result<TransactionPolicyResponse>> UpdatePolicyAsync(string categoryString, UpdateTransactionPolicyRequest request, CancellationToken ct = default);
    Task<Result<PaymentSourcePolicy>> GetPolicyForCategoryAsync(GlobalTransactionCategory category, CancellationToken ct = default);
}
