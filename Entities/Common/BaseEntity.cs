namespace Centraly.Api.Entities.Common;

public abstract class BaseEntity : ISoftDelete
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string? CreatedByUserId { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedByUserId { get; set; }

    [NotMapped]
    public bool IsUpdated => UpdatedAt.HasValue;

    public bool IsDeleted { get; set; } = false;

    public DateTime? DeletedAt { get; set; }
}
