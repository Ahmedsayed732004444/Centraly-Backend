namespace Centraly.Api.Errors;

public record WalletErrors
{
    public static readonly Error NotFound =
        new("Wallet.NotFound", "المحفظة غير موجودة", StatusCodes.Status404NotFound);

    public static readonly Error WalletNotFound = NotFound;

    public static readonly Error Inactive =
        new("Wallet.Inactive", "المحفظة غير مفعّلة", StatusCodes.Status400BadRequest);

    public static readonly Error InsufficientBalance =
        new("Wallet.InsufficientBalance", "رصيد المحفظة غير كافٍ", StatusCodes.Status400BadRequest);

    public static readonly Error InvalidOperation =
        new("Wallet.InvalidOperation", "نوع العملية غير صالح", StatusCodes.Status400BadRequest);
}
