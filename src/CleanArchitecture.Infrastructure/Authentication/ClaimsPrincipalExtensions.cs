using System.Security.Claims;

namespace CleanArchitecture.Infrastructure.Authentication;

internal static class ClaimsPrincipalExtensions
{
    public static Guid? GetUserId(this ClaimsPrincipal principal)
    {
        var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            return null;
        }

        return Guid.Parse(userId);
    }
}
