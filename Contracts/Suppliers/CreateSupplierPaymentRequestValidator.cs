using FluentValidation;

namespace Centraly.Api.Contracts.Suppliers;

public class CreateSupplierPaymentRequestValidator : AbstractValidator<CreateSupplierPaymentRequest>
{
    public CreateSupplierPaymentRequestValidator()
    {
        RuleFor(x => x.SupplierId).NotEmpty();
        RuleFor(x => x.Amount).NotEqual(0).WithMessage("مبلغ الدفعة يجب ألا يكون صفراً");
        RuleFor(x => x.Notes).MaximumLength(500).When(x => !string.IsNullOrWhiteSpace(x.Notes));
    }
}