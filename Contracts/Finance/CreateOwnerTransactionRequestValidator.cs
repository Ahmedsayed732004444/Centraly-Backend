using FluentValidation;

namespace Centraly.Api.Contracts.Finance;

public class CreateOwnerTransactionRequestValidator : AbstractValidator<CreateOwnerTransactionRequest>
{
    public CreateOwnerTransactionRequestValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0);

        RuleFor(x => x.Notes)
            .MaximumLength(500)
            .When(x => !string.IsNullOrWhiteSpace(x.Notes));
    }
}
