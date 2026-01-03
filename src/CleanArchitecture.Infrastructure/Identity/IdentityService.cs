using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Dtos.Users;
using CleanArchitecture.Infrastructure.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserResponse> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

        return user?.ToUserResponse();
    }

    public async Task<UserResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return user?.ToUserResponse();
    }

    public async Task<bool> CheckPasswordAsync(string email, string password, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

        if (user == null)
        {
            throw new Exception("User not found.");
        }

        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<bool> IsAnyByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _userManager.Users.AnyAsync(x => x.Email == email, cancellationToken);
    }

    public async Task CreateAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        await _userManager.CreateAsync(user, request.Password);
    }
}
