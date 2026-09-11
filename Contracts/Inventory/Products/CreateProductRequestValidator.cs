using FluentValidation;

namespace Centraly.Api.Contracts.Inventory.Products;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Barcode)
            .MaximumLength(64)
            .When(x => !string.IsNullOrWhiteSpace(x.Barcode));

        RuleFor(x => x.Name)
            .MaximumLength(200)
            .When(x => !string.IsNullOrWhiteSpace(x.Name));

        RuleFor(x => x.DepartmentId)
            .NotEmpty();

        RuleFor(x => x.CategoryId)
            .NotEmpty();

        RuleFor(x => x.MinQuantityAlert)
            .GreaterThanOrEqualTo(0);
    }
}