using Centraly.Api.Entities.Notifications;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.Property(n => n.TitleAr).HasMaxLength(200).IsRequired();
        builder.Property(n => n.BodyAr).HasMaxLength(1000).IsRequired();
        builder.Property(n => n.EntityType).HasMaxLength(50);
        builder.Property(n => n.Link).HasMaxLength(300);

        // The notification bell always queries "this user's unread, newest first" -
        // this is the one index that matters for that.
        builder.HasIndex(n => new { n.UserId, n.IsRead, n.CreatedAt });
    }
}
