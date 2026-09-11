namespace Centraly.Api.Contracts.Inventory.Departments;

public class UpdateDepartmentRequestValidator : AbstractValidator<UpdateDepartmentRequest>
{
    public UpdateDepartmentRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(2, 150);
    }
}
