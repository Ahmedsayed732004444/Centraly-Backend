namespace Centraly.Api.Contracts.Customers;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Phone)
            .Matches(@"^01[0125][0-9]{8}$")
            .When(x => !string.IsNullOrWhiteSpace(x.Phone));
    }
}
