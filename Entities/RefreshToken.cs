namespace Centraly.Api.Entities;

public class RefreshToken
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresOn { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? RevokedOn { get; set; }

    public bool IsExpired => DateTime.UtcNow >= ExpiresOn;
    public bool IsActive => RevokedOn is null && !IsExpired;
}