namespace Centraly.Api.Contracts.Inventory.Categories;

public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(2, 150);

        RuleFor(x => x.DepartmentId)
            .NotEmpty();
    }
}
