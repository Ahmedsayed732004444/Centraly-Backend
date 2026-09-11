namespace Centraly.Api.Controllers;

[ApiController]
[Route("finance-policies")]
[Authorize(Roles = "Admin,Manager")]
public class FinancePolicyController(IFinancePolicyService _financePolicyService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPoliciesAsync(CancellationToken ct)
    {
        var result = await _financePolicyService.GetPoliciesAsync(ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{category}")]
    public async Task<IActionResult> UpdatePolicyAsync(string category, [FromBody] UpdateTransactionPolicyRequest request, CancellationToken ct)
    {
        var result = await _financePolicyService.UpdatePolicyAsync(category, request, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}


