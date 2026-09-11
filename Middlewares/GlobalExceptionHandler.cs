using Microsoft.AspNetCore.Diagnostics;

namespace Centraly.Api.Middlewares;

// Catches anything that escapes the Result pipeline (a bug, a DB timeout, an
// unguarded null-ref) so the client always gets the same Arabic ProblemDetails shape
// as a normal business-error response - errors:[code, description] - instead of a raw
// .NET exception page (Development) or an empty 500 (Production).
public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Unhandled exception for {Method} {Path}", httpContext.Request.Method, httpContext.Request.Path);

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        httpContext.Response.ContentType = "application/problem+json";

        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "حدث خطأ غير متوقع",
            Extensions =
            {
                ["errors"] = new[] { "Server.UnexpectedError", "حدث خطأ غير متوقع في الخادم، برجاء المحاولة لاحقاً" }
            }
        };

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}
