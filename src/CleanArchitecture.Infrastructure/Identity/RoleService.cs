using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Dtos.Roles;
using CleanArchitecture.Infrastructure.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Identity;

public class RoleService : IRoleService
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public RoleService(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task<RoleDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return role?.ToRoleDto();
    }

    public async Task<IEnumerable<RoleDto>> GetAsync(CancellationToken cancellationToken)
    {
        var roles = await _roleManager.Roles.ToListAsync(cancellationToken);

        return roles.ToRoleDtos();
    }

    public async Task CreateAsync(CreateRoleRequest request)
    {
        var role = new ApplicationRole
        {
            Name = request.Name
        };

        var result = await _roleManager.CreateAsync(role);

        if (!result.Succeeded)
        {
            throw new Exception(string.Join("; ", result.Errors.Select(x => x.Description)));
        }
    }

    public async Task UpdateAsync(UpdateRoleRequest request, CancellationToken cancellationToken)
    {
        var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (role == null)
        {
            throw new Exception($"Role not found.");
        }

        role.Name = request.Name;

        var result = await _roleManager.UpdateAsync(role);

        if (!result.Succeeded)
        {
            throw new Exception(string.Join("; ", result.Errors.Select(x => x.Description)));
        }
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (role == null)
        {
            throw new Exception($"Role not found.");
        }

        var result = await _roleManager.DeleteAsync(role);

        if (!result.Succeeded)
        {
            throw new Exception(string.Join("; ", result.Errors.Select(x => x.Description)));
        }
    }

    public async Task AssignRolesAsync(Guid userId, IEnumerable<UserRoleDto> roles, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);

        if (user == null)
        {
            throw new Exception("User not found.");
        }

        foreach (var userRole in roles)
        {
            if (await _roleManager.FindByNameAsync(userRole.Name) == null)
            {
                continue;
            }

            if (userRole.Enabled)
            {
                if (await _userManager.IsInRoleAsync(user, userRole.Name))
                {
                    continue;
                }

                await _userManager.AddToRoleAsync(user, userRole.Name);
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, userRole.Name);
            }
        }
    }
}
