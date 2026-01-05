using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.Infrastructure.Authorization;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IIdentityService _identityService;

    public PermissionAuthorizationHandler(IIdentityService _identityService)
    {
        this._identityService = _identityService;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        var permissions = requirement.Permission.Split(',');

        foreach (var permission in permissions)
        {
            if (context.User?.GetUserId() is { } userId && await _identityService.HasPermissionAsync(userId, permission.Trim()))
            {
                context.Succeed(requirement);
                return;
            }
        }
    }
}