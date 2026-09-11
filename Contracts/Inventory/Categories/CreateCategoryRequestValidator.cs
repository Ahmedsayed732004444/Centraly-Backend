namespace Centraly.Api.Contracts.Inventory.Categories;

public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(2, 150);

        RuleFor(x => x.DepartmentId)
            .NotEmpty();
    }
}
