using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.Infrastructure.Authorization;

public class MustHavePermissionAttribute : AuthorizeAttribute
{
    public MustHavePermissionAttribute(string action, string resource)
    {
        Policy = Permission.NameFor(action, resource);
    }
}