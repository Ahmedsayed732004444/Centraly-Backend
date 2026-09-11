using FluentValidation;

namespace Centraly.Api.Contracts.Sales;

public class CreateSalesInvoiceItemRequestValidator : AbstractValidator<CreateSalesInvoiceItemRequest>
{
    public CreateSalesInvoiceItemRequestValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.BatchId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.SellingPrice).GreaterThanOrEqualTo(0);
    }
}

public class CreateSalesInvoiceRequestValidator : AbstractValidator<CreateSalesInvoiceRequest>
{
    public CreateSalesInvoiceRequestValidator()
    {
        RuleFor(x => x.SaleType).IsInEnum();
        RuleFor(x => x.PaymentMethod).IsInEnum();
        RuleFor(x => x.PaidAmount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Notes).MaximumLength(500);
        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("يجب أن تحتوي الفاتورة على صنف واحد على الأقل");
            
        RuleForEach(x => x.Items).SetValidator(new CreateSalesInvoiceItemRequestValidator());
        
        // Ensure no duplicate batch in items
        RuleFor(x => x.Items)
            .Must(items => items.Select(i => i.BatchId).Distinct().Count() == items.Count)
            .When(x => x.Items != null && x.Items.Any())
            .WithMessage("يوجد تكرار في الأصناف. لا يمكن إضافة نفس الدفعة أكثر من مرة");
    }
}
