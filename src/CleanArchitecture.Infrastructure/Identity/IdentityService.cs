using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Dtos.Users;
using CleanArchitecture.Infrastructure.Authentication;
using CleanArchitecture.Infrastructure.Database;
using CleanArchitecture.Infrastructure.Mappers;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly ApplicationDbContext _context;

    public IdentityService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
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

    public async Task<Guid> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new Exception(string.Join("; ", result.Errors.Select(x => x.Description)));
        }

        return user.Id;
    }

    public async Task<bool> HasPermissionAsync(Guid userId, string permission)
    {
        var permissions = await GetPermissionsAsync(userId);

        return permissions?.Contains(permission) ?? false;
    }

    public async Task<List<string>> GetPermissionsAsync(Guid userId)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

        if (user == null)
        {
            throw new Exception("User not found.");
        }

        var userRoles = await _userManager.GetRolesAsync(user);

        var permissions = new List<string>();

        foreach (var role in await _roleManager.Roles.Where(r => userRoles.Contains(r.Name!)).ToListAsync())
        {
            permissions.AddRange(await _context.RoleClaims
                       .Where(x => x.RoleId == role.Id && x.ClaimType == Claims.Permission)
                       .Select(x => x.ClaimValue!)
                       .ToListAsync());
        }

        return permissions.Distinct().ToList();
    }

    public async Task<IEnumerable<string>> GetRolesAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);

        if (user == null)
        {
            throw new Exception("User not found.");
        }

        return await _userManager.GetRolesAsync(user);
    }

    public async Task<Guid> UpdateAsync(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (user == null)
        {
            throw new Exception("User not found.");
        }

        user.Email = request.Email;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            throw new Exception(string.Join("; ", result.Errors.Select(x => x.Description)));
        }

        return user.Id;
    }
}
