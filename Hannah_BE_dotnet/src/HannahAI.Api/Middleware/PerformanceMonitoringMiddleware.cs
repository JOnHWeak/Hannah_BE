using System.Diagnostics;

namespace HannahAI.Api.Middleware;

public class PerformanceMonitoringMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<PerformanceMonitoringMiddleware> _logger;

    public PerformanceMonitoringMiddleware(RequestDelegate next, ILogger<PerformanceMonitoringMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        await _next(context);

        stopwatch.Stop();

        if (stopwatch.ElapsedMilliseconds > 500) // Log requests that take longer than 500ms
        {
            _logger.LogWarning("Long-running request: {Method} {Path} ({ElapsedMilliseconds}ms)",
                context.Request.Method,
                context.Request.Path,
                stopwatch.ElapsedMilliseconds);
        }
    }
}

