using CleanArchitecture.Application.Abstractions.CurrentUser;
using System.Security.Claims;

namespace CleanArchitecture.Infrastructure.Authentication;

public class CurrentUser : ICurrentUserInitializer, ICurrentUser
{
    private ClaimsPrincipal? _user;

    public Guid? GetUserId()
    {
        if (IsAuthenticated())
        {
            return _user?.GetUserId() ?? Guid.Empty;
        }

        return null;
    }

    public bool IsAuthenticated()
    {
        return _user?.Identity?.IsAuthenticated is true;
    }

    public void SetCurrentUser(ClaimsPrincipal user)
    {
        if (_user != null)
        {
            throw new Exception("User context is unavailable");
        }

        _user = user;
    }
}
