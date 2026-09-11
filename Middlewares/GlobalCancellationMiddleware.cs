using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Centraly.Api.Middlewares;

public class GlobalCancellationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalCancellationMiddleware> _logger;

    public GlobalCancellationMiddleware(RequestDelegate next, ILogger<GlobalCancellationMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Request was cancelled by the client.");
            context.Response.StatusCode = 499; // Client Closed Request
        }
        catch (Exception ex) when (ex.InnerException is OperationCanceledException || ex is TaskCanceledException)
        {
            _logger.LogInformation("Request was cancelled by the client (TaskCanceledException).");
            context.Response.StatusCode = 499; // Client Closed Request
        }
    }
}
