using Centraly.Api;
using Centraly.Api.Hubs;
using Centraly.Api.Services.Abstraction;
using Hangfire;
using HangfireBasicAuthenticationFilter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDependencies(builder.Configuration);

builder.Services.AddAuthorization(options =>
{
    foreach (var permission in Centraly.Api.Abstractions.Consts.Permissions.GetAllPermissions())
    {
        if (!string.IsNullOrEmpty(permission))
        {
            options.AddPolicy(permission, policy => policy.RequireClaim(Centraly.Api.Abstractions.Consts.Permissions.Type, permission));
        }
    }
});

var app = builder.Build();

// Must wrap everything downstream, so it's the first middleware registered.
app.UseExceptionHandler();

app.UseMiddleware<Centraly.Api.Middlewares.GlobalCancellationMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHangfireDashboard("/jobs", new DashboardOptions
{
    Authorization =
    [
        new HangfireCustomBasicAuthenticationFilter
        {
            User = app.Configuration.GetValue<string>("HangfireSettings:Username"),
            Pass = app.Configuration.GetValue<string>("HangfireSettings:Password")
        }
    ],
    DashboardTitle = "3lmny Dashboard",
    //IsReadOnlyFunc = (DashboardContext context) => true 
});
app.UseHttpsRedirection();

app.UseCors();

// Explicit (was previously implicit via WebApplication auto-registration): the JWT
// query-string handler for /hubs paths in Dependencies.cs needs UseAuthentication to
// actually run before UseAuthorization/the Hub's [Authorize] can see the principal.
app.UseAuthentication();

// Ensure uploads directory exists
var uploadsPath = Path.Combine(builder.Environment.ContentRootPath, "uploads");
if (!Directory.Exists(uploadsPath))
{
    Directory.CreateDirectory(uploadsPath);
}

// Serve files from uploads folder
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();
app.MapHub<NotificationHub>("/hubs/notifications");

RecurringJob.AddOrUpdate<INotificationBackgroundJobs>(
    "maintenance-tickets-check",
    job => job.CheckMaintenanceTicketsAsync(CancellationToken.None),
    Cron.Hourly);

RecurringJob.AddOrUpdate<INotificationBackgroundJobs>(
    "drawer-left-open-check",
    job => job.CheckDrawerSessionsLeftOpenAsync(CancellationToken.None),
    Cron.Hourly);

app.Run();

