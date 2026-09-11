namespace Centraly.Api.Contracts.Suppliers;

public class UpdateSupplierRequestValidator : AbstractValidator<UpdateSupplierRequest>
{
    public UpdateSupplierRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(2, 150);
        RuleFor(x => x.Type).MaximumLength(100).When(x => !string.IsNullOrWhiteSpace(x.Type));
        RuleFor(x => x.Phone).Matches(@"^01[0125][0-9]{8}$").When(x => !string.IsNullOrWhiteSpace(x.Phone));
        RuleFor(x => x.Address).MaximumLength(300).When(x => !string.IsNullOrWhiteSpace(x.Address));
    }
}
