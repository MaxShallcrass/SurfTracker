using Microsoft.AspNetCore.Diagnostics;
using SurfTrackerBackend.Models.DTOs;

namespace SurfTrackerBackend.Middleware;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Unhandled exception");

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsJsonAsync(
            new ErrorResponse("An unexpected error occurred."),
            cancellationToken);

        return true;
    }
}
