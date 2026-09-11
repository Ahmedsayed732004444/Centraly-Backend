namespace Centraly.Api.Errors;

public static class UserErrors
{
    public static readonly Error InvalidCredentials =
        new("User.InvalidCredentials", "البريد الإلكتروني أو كلمة المرور غير صحيحة", StatusCodes.Status401Unauthorized);

    public static readonly Error DuplicateEmail =
        new("User.DuplicateEmail", "يوجد مستخدم آخر بنفس البريد الإلكتروني", StatusCodes.Status409Conflict);

    public static readonly Error EmailNotConfirmed =
        new("User.EmailNotConfirmed", "البريد الإلكتروني غير مؤكد", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidRefreshToken =
        new("User.InvalidRefreshToken", "رمز التجديد غير صالح", StatusCodes.Status401Unauthorized);

    public static readonly Error LockedUser =
        new("User.LockedUser", "الحساب مغلق، يرجى التواصل مع الإدارة", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidToken =
        new("User.InvalidToken", "الرمز غير صالح", StatusCodes.Status400BadRequest);

    public static readonly Error DuplicateEmailConfirmed =
        new("User.DuplicateEmailConfirmed", "يوجد مستخدم آخر بنفس البريد الإلكتروني مؤكد بالفعل", StatusCodes.Status409Conflict);

    public static readonly Error UserNotFound =
        new("User.UserNotFound", "المستخدم غير موجود", StatusCodes.Status404NotFound);

    public static readonly Error InvalidPassword =
        new("User.InvalidPassword", "كلمة المرور الحالية غير صحيحة", StatusCodes.Status401Unauthorized);
    public static readonly Error DisabledUser =
        new("User.DisabledUser", "الحساب معطل، يرجى التواصل مع الإدارة", StatusCodes.Status401Unauthorized);
    public static readonly Error UnexpectedError =
        new("User.UnexpectedError", "حدث خطأ غير متوقع", StatusCodes.Status500InternalServerError);
    public static readonly Error InvalidJwtToken =
        new("User.InvalidJwtToken", "رمز الدخول غير صالح", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidRoles =
        new("User.InvalidRoles", "أحد الأدوار المحددة غير صالح", StatusCodes.Status400BadRequest);

}
