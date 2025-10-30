using System.Net;
using System.Text.Json;

namespace HannahAI.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception has occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var response = context.Response;

        var errorResponse = new
        {
            message = "An internal server error has occurred.",
            details = (string?)null
        };

        switch (exception)
        {
            case Domain.Exceptions.ValidationException validationException:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorResponse = new { message = "Validation failed.", details = JsonSerializer.Serialize(validationException.Errors) };
                break;
            case Domain.Exceptions.NotFoundException:
                response.StatusCode = (int)HttpStatusCode.NotFound;
                errorResponse = new { message = "The requested resource was not found.", details = (string?)null };
                break;
            case Domain.Exceptions.UnauthorizedException:
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                errorResponse = new { message = "Unauthorized access.", details = (string?)null };
                break;
            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        var result = JsonSerializer.Serialize(errorResponse);
        return context.Response.WriteAsync(result);
    }
}
