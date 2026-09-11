namespace Centraly.Api.Contracts.Suppliers;

public class CreatePurchaseInvoiceItemRequestValidator : AbstractValidator<CreatePurchaseInvoiceItemRequest>
{
    public CreatePurchaseInvoiceItemRequestValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.UnitCost).GreaterThanOrEqualTo(0);
    }
}

public class CreatePurchaseInvoiceRequestValidator : AbstractValidator<CreatePurchaseInvoiceRequest>
{
    public CreatePurchaseInvoiceRequestValidator()
    {
        RuleFor(x => x.SupplierId).NotEmpty();
        RuleFor(x => x.PaidAmount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Notes).MaximumLength(500).When(x => !string.IsNullOrWhiteSpace(x.Notes));

        RuleFor(x => x.Items)
            .NotNull()
            .NotEmpty()
            .WithMessage("يجب أن تحتوي فاتورة المشتريات على صنف واحد على الأقل");

        RuleForEach(x => x.Items).SetValidator(new CreatePurchaseInvoiceItemRequestValidator());

        RuleFor(x => x.Items)
            .Must(items => items.Select(i => i.ProductId).Distinct().Count() == items.Count)
            .WithMessage("لا يمكن إضافة نفس المنتج مرتين في نفس فاتورة المشتريات")
            .When(x => x.Items != null);
    }
}
