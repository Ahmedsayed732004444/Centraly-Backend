namespace Centraly.Api.Errors;

public record RoleErrors
{
    public static readonly Error RoleNotFound =
        new("Role.RoleNotFound", "الدور غير موجود", StatusCodes.Status404NotFound);

    public static readonly Error InvalidPermissions =
        new("Role.InvalidPermissions", "الصلاحيات المحددة غير صالحة", StatusCodes.Status400BadRequest);

    public static readonly Error DuplicatedRole =
        new("Role.DuplicatedRole", "يوجد دور آخر بنفس الاسم", StatusCodes.Status409Conflict);
}
