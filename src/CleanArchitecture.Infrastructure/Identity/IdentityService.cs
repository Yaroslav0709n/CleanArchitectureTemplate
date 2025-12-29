using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Users.Dto;
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
        var user = await _userManager.Users.Select(x => new UserResponse
                                           {
                                                Id = x.Id,
                                                Email = x.Email,
                                                FirstName = x.FirstName,
                                                LastName  = x.LastName,
                                           })
                                           .FirstOrDefaultAsync(x => x.Email == email);

        return user;
    }

    public async Task<UserResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.Select(x => new UserResponse
                                           {
                                                Id = x.Id,
                                                Email = x.Email,
                                                FirstName = x.FirstName,
                                                LastName = x.LastName,
                                           })
                                           .FirstOrDefaultAsync(x => x.Id == id);

        return user;
    }

    public async Task<bool> CheckPasswordAsync(string email, string password, CancellationToken cancellationToken)
    {
        var user = _userManager.Users.FirstOrDefault(x => x.Email == email);

        if (user == null)
        {
            throw new Exception("User not found.");
        }

        return await _userManager.CheckPasswordAsync(user, password);
    }
}
