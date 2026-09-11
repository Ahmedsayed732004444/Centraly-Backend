namespace Centraly.Api.Contracts.Users;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("اسم المستخدم مطلوب")
            .MaximumLength(100)
            .WithMessage("اسم المستخدم يجب ألا يتجاوز 100 حرف");

        RuleFor(x => x.Roles)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Roles)
            .Must(x => x.Distinct().Count() == x.Count)
            .WithMessage("لا يمكن تكرار نفس الدور للمستخدم")
            .When(x => x.Roles != null);
    }
}