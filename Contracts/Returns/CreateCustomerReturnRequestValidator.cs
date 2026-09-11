using FluentValidation;

namespace Centraly.Api.Contracts.Returns;

public class CreateCustomerReturnRequestValidator : AbstractValidator<CreateCustomerReturnRequest>
{
    public CreateCustomerReturnRequestValidator()
    {
        RuleFor(x => x.InvoiceId).NotEmpty();
        RuleFor(x => x.Reason).IsInEnum();
        RuleFor(x => x.Notes).MaximumLength(500).When(x => !string.IsNullOrWhiteSpace(x.Notes));
        RuleFor(x => x.Items).NotNull().NotEmpty().WithMessage("يجب أن يحتوي المرتجع على صنف واحد على الأقل");
    }
}
