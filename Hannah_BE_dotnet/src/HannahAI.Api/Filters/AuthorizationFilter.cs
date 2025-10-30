using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace HannahAI.Api.Filters;

public class AuthorizationFilter : IAuthorizationFilter
{
    private readonly string[] _roles;

    public AuthorizationFilter(params string[] roles)
    {
        _roles = roles;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        if (!user.Identity?.IsAuthenticated ?? true)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (_roles.Any() && !_roles.Any(role => user.IsInRole(role)))
        {
            context.Result = new ForbidResult();
        }
    }
}

