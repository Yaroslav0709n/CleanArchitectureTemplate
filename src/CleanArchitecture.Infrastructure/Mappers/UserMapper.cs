using CleanArchitecture.Application.Dtos.Users;
using CleanArchitecture.Infrastructure.Identity;

namespace CleanArchitecture.Infrastructure.Mappers;

public static class UserMapper
{
    public static UserResponse ToUserResponse(this ApplicationUser user)
    {
        return new UserResponse
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }
}
