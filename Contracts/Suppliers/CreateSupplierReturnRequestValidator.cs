using FluentValidation;

namespace Centraly.Api.Contracts.Suppliers;

public class CreateSupplierReturnItemRequestValidator : AbstractValidator<CreateSupplierReturnItemRequest>
{
    public CreateSupplierReturnItemRequestValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
    }
}

public class CreateSupplierReturnRequestValidator : AbstractValidator<CreateSupplierReturnRequest>
{
    public CreateSupplierReturnRequestValidator()
    {
        RuleFor(x => x.SupplierId).NotEmpty();
        RuleFor(x => x.Reason).IsInEnum();
        RuleFor(x => x.Notes).MaximumLength(500).When(x => !string.IsNullOrWhiteSpace(x.Notes));

        RuleFor(x => x.Items)
            .NotNull()
            .NotEmpty()
            .WithMessage("يجب أن يحتوي مرتجع المورد على صنف واحد على الأقل");

        RuleForEach(x => x.Items).SetValidator(new CreateSupplierReturnItemRequestValidator());

        RuleFor(x => x.Items)
            .Must(items => items.Select(i => i.ProductId).Distinct().Count() == items.Count)
            .WithMessage("لا يمكن إضافة نفس المنتج مرتين في نفس المرتجع")
            .When(x => x.Items != null);
    }
}