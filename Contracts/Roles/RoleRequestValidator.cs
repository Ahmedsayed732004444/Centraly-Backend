namespace Centraly.Api.Contracts.Roles;

public class RoleRequestValidator : AbstractValidator<RoleRequest>
{
    public RoleRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(3, 200);

        RuleFor(x => x.Permissions)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Permissions)
            .Must(x => x.Distinct().Count() == x.Count)
            .WithMessage("لا يمكن تكرار نفس الصلاحية للدور")
            .When(x => x.Permissions != null);
    }
}