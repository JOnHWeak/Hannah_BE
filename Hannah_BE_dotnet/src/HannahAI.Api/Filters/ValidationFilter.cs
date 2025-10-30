using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HannahAI.Api.Filters;

public class ValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray());

            var errorResponse = new
            {
                message = "Validation Failed",
                errors
            };

            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}

