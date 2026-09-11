namespace Centraly.Api.Authentication;

// ASP.NET Identity's default IdentityErrorDescriber only produces English messages
// (e.g. "Passwords must have at least one digit ('0'-'9')."), and those Descriptions
// flow straight into the client-facing Error in UserService/RoleService. Overriding
// every message here means the fix applies everywhere IdentityResult.Errors is
// surfaced, with no changes needed at each call site.
public class ArabicIdentityErrorDescriber : IdentityErrorDescriber
{
    public override IdentityError DefaultError() => new()
    {
        Code = nameof(DefaultError),
        Description = "حدث خطأ غير متوقع"
    };

    public override IdentityError ConcurrencyFailure() => new()
    {
        Code = nameof(ConcurrencyFailure),
        Description = "فشلت العملية بسبب تعديل آخر متزامن على نفس البيانات"
    };

    public override IdentityError PasswordMismatch() => new()
    {
        Code = nameof(PasswordMismatch),
        Description = "كلمة المرور غير صحيحة"
    };

    public override IdentityError InvalidToken() => new()
    {
        Code = nameof(InvalidToken),
        Description = "الرمز غير صالح"
    };

    public override IdentityError RecoveryCodeRedemptionFailed() => new()
    {
        Code = nameof(RecoveryCodeRedemptionFailed),
        Description = "فشل استخدام رمز الاسترداد"
    };

    public override IdentityError LoginAlreadyAssociated() => new()
    {
        Code = nameof(LoginAlreadyAssociated),
        Description = "يوجد مستخدم آخر مرتبط بهذا الحساب بالفعل"
    };

    public override IdentityError InvalidUserName(string? userName) => new()
    {
        Code = nameof(InvalidUserName),
        Description = "اسم المستخدم غير صالح، يجب أن يحتوي على حروف أو أرقام فقط"
    };

    public override IdentityError InvalidEmail(string? email) => new()
    {
        Code = nameof(InvalidEmail),
        Description = "البريد الإلكتروني غير صالح"
    };

    public override IdentityError DuplicateUserName(string userName) => new()
    {
        Code = nameof(DuplicateUserName),
        Description = "يوجد مستخدم آخر بنفس الاسم بالفعل"
    };

    public override IdentityError DuplicateEmail(string email) => new()
    {
        Code = nameof(DuplicateEmail),
        Description = "يوجد مستخدم آخر بنفس البريد الإلكتروني بالفعل"
    };

    public override IdentityError InvalidRoleName(string? role) => new()
    {
        Code = nameof(InvalidRoleName),
        Description = "اسم الدور غير صالح"
    };

    public override IdentityError DuplicateRoleName(string role) => new()
    {
        Code = nameof(DuplicateRoleName),
        Description = "يوجد دور آخر بنفس الاسم بالفعل"
    };

    public override IdentityError UserAlreadyHasPassword() => new()
    {
        Code = nameof(UserAlreadyHasPassword),
        Description = "المستخدم لديه كلمة مرور بالفعل"
    };

    public override IdentityError UserLockoutNotEnabled() => new()
    {
        Code = nameof(UserLockoutNotEnabled),
        Description = "خاصية إيقاف الحساب غير مفعّلة لهذا المستخدم"
    };

    public override IdentityError UserAlreadyInRole(string role) => new()
    {
        Code = nameof(UserAlreadyInRole),
        Description = "المستخدم لديه هذا الدور بالفعل"
    };

    public override IdentityError UserNotInRole(string role) => new()
    {
        Code = nameof(UserNotInRole),
        Description = "المستخدم ليس لديه هذا الدور"
    };

    public override IdentityError PasswordTooShort(int length) => new()
    {
        Code = nameof(PasswordTooShort),
        Description = $"كلمة المرور يجب أن تكون {length} حروف على الأقل"
    };

    public override IdentityError PasswordRequiresUniqueChars(int uniqueChars) => new()
    {
        Code = nameof(PasswordRequiresUniqueChars),
        Description = $"كلمة المرور يجب أن تحتوي على {uniqueChars} حروف مختلفة على الأقل"
    };

    public override IdentityError PasswordRequiresNonAlphanumeric() => new()
    {
        Code = nameof(PasswordRequiresNonAlphanumeric),
        Description = "كلمة المرور يجب أن تحتوي على رمز واحد على الأقل (مثل !@#$)"
    };

    public override IdentityError PasswordRequiresDigit() => new()
    {
        Code = nameof(PasswordRequiresDigit),
        Description = "كلمة المرور يجب أن تحتوي على رقم واحد على الأقل"
    };

    public override IdentityError PasswordRequiresLower() => new()
    {
        Code = nameof(PasswordRequiresLower),
        Description = "كلمة المرور يجب أن تحتوي على حرف إنجليزي صغير واحد على الأقل"
    };

    public override IdentityError PasswordRequiresUpper() => new()
    {
        Code = nameof(PasswordRequiresUpper),
        Description = "كلمة المرور يجب أن تحتوي على حرف إنجليزي كبير واحد على الأقل"
    };
}
