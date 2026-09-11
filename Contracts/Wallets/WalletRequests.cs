using Centraly.Api.Entities.Wallets;

namespace Centraly.Api.Contracts.Wallets;

public record CreateWalletRequest(
    string Name,
    string PhoneNumber,
    string? OwnerName,
    decimal InitialBalance,
    List<WalletOperationType>? AllowedOperations,
    IFormFile Image);

public class CreateWalletRequestValidator : AbstractValidator<CreateWalletRequest>
{
    public CreateWalletRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(20);
        RuleFor(x => x.OwnerName).MaximumLength(100);
        RuleFor(x => x.InitialBalance).GreaterThanOrEqualTo(0);
    }
}

public record ProcessOperationRequest(
    string WalletId,
    WalletOperationType OperationType,
    decimal TransferredAmount,
    decimal PhysicalCashAmount,
    string? Notes);

public class ProcessOperationRequestValidator : AbstractValidator<ProcessOperationRequest>
{
    public ProcessOperationRequestValidator()
    {
        RuleFor(x => x.WalletId).NotEmpty();
        RuleFor(x => x.OperationType).IsInEnum();
        RuleFor(x => x.TransferredAmount).GreaterThan(0);
        RuleFor(x => x.PhysicalCashAmount).GreaterThan(0);
        RuleFor(x => x.Notes).MaximumLength(500);
    }
}

public record UpdateWalletRequest(
    string Name, 
    string PhoneNumber, 
    string? OwnerName, 
    bool IsActive,
    List<WalletOperationType>? AllowedOperations,
    IFormFile? Image);

public class UpdateWalletRequestValidator : AbstractValidator<UpdateWalletRequest>
{
    public UpdateWalletRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(20);
        RuleFor(x => x.OwnerName).MaximumLength(100);
    }
}

public record WalletOperationFilter : Centraly.Api.Contracts.Common.PaginationFilter
{
    public string? WalletId { get; init; }
    public WalletOperationType? OperationType { get; init; }
    public DateTime? DateFrom { get; init; }
    public DateTime? DateTo { get; init; }
}
