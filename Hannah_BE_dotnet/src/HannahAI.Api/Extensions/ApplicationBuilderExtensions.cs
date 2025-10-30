using HannahAI.Api.Middleware;

namespace HannahAI.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseMiddleware<RequestLoggingMiddleware>();
        app.UseMiddleware<PerformanceMonitoringMiddleware>();

        return app;
    }
}

