using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TikRandevu.API.Middlewares;

public class UnhandledExceptionHandlingMiddleware(
    ILogger<UnhandledExceptionHandlingMiddleware> logger)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Unhandled Exception Occured");

        var problemDetails = new ProblemDetails
        {
            Title = "Server Failure - Unhandled Exception",
            Status = StatusCodes.Status500InternalServerError,
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}