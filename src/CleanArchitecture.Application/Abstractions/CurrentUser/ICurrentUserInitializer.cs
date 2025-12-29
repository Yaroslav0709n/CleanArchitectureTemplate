using System.Security.Claims;

namespace CleanArchitecture.Application.Abstractions.CurrentUser;

public interface ICurrentUserInitializer
{
    void SetCurrentUser(ClaimsPrincipal user);
}
