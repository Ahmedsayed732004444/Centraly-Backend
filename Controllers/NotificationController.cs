namespace Centraly.Api.Controllers;

[Route("notifications")]
[ApiController]
[Authorize]
public class NotificationController(INotificationService notificationService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] RequestFilters filters, [FromQuery] bool unreadOnly, CancellationToken ct)
    {
        var result = await notificationService.GetForUserAsync(User.GetUserId()!, filters, unreadOnly, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("unread-count")]
    public async Task<IActionResult> GetUnreadCount(CancellationToken ct)
    {
        var result = await notificationService.GetUnreadCountAsync(User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("{id}/read")]
    public async Task<IActionResult> MarkAsRead(string id, CancellationToken ct)
    {
        var result = await notificationService.MarkAsReadAsync(User.GetUserId()!, id, ct);
        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }

    [HttpPost("read-all")]
    public async Task<IActionResult> MarkAllAsRead(CancellationToken ct)
    {
        var result = await notificationService.MarkAllAsReadAsync(User.GetUserId()!, ct);
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
}
