namespace Centraly.Api.Abstractions.Consts;

public static class RegexPatterns
{
    //public const string Email = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    public const string EgyptianPhonePattern =
    @"^(?:\+20|0)?1[0125][0-9]{8}$";
    public const string PasswordPattern = 
    "(?=(.*[0-9]))(?=.*[\\!@#$%^&*()\\\\[\\]{}\\-_+=~`|:;\"'<>,./?])(?=.*[a-z])(?=(.*[A-Z]))(?=(.*)).{8,}";
}
