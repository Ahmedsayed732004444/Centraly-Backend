using FluentValidation;

namespace Centraly.Api.Contracts.Inventory.Products;

public class AdjustProductQuantityRequestValidator : AbstractValidator<AdjustProductQuantityRequest>
{
    public AdjustProductQuantityRequestValidator()
    {
        RuleFor(x => x.BatchId)
            .NotEmpty();

        RuleFor(x => x.NewQuantity)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Reason)
            .MaximumLength(300)
            .When(x => !string.IsNullOrWhiteSpace(x.Reason));
    }
}