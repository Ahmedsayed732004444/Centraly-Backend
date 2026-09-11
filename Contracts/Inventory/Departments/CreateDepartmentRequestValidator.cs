namespace Centraly.Api.Contracts.Inventory.Departments;

public class CreateDepartmentRequestValidator : AbstractValidator<CreateDepartmentRequest>
{
    public CreateDepartmentRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(2, 150);
    }
}
