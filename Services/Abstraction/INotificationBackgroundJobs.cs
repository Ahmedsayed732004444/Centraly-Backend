namespace Centraly.Api.Services.Abstraction;

// Hangfire recurring jobs live behind an interface (registered under
// Centraly.Api.Services.Implementation so the existing services.Scan(...) picks it up
// automatically as scoped) so RecurringJob.AddOrUpdate<T> in Program.cs can resolve a
// fresh instance - and a real DbContext/INotificationService - on every scheduled run.
public interface INotificationBackgroundJobs
{
    // Maintenance tickets: "due soon" (within the next 2 hours) and "overdue"
    // (past DeliveryDate, still Pending). Each ticket is notified at most once per
    // type - see the dedup check against existing Notification rows.
    Task CheckMaintenanceTicketsAsync(CancellationToken ct = default);

    // Drawer/Maintenance shift sessions left open more than 12 hours - almost always
    // means someone forgot to close out at the end of the day.
    Task CheckDrawerSessionsLeftOpenAsync(CancellationToken ct = default);
}
