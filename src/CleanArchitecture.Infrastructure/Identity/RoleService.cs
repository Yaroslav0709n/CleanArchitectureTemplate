using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Dtos.Roles;
using CleanArchitecture.Infrastructure.Database;
using CleanArchitecture.Infrastructure.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Identity;

public class RoleService : IRoleService
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public RoleService(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _context = context;
    }

    public async Task<RoleDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return role?.ToRoleDto();
    }

    public async Task<IEnumerable<RoleDto>> GetListAsync(CancellationToken cancellationToken)
    {
        var roles = await _roleManager.Roles.ToListAsync(cancellationToken);

        return roles.ToRoleDtos();
    }

    public async Task<Guid> CreateAsync(CreateRoleRequest request)
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

        return role.Id;
    }

    public async Task<Guid> UpdateAsync(UpdateRoleRequest request, CancellationToken cancellationToken)
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

        return role.Id;
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

    public async Task AssignRolesAsync(Guid userId, IEnumerable<string> roles, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);

        if (user == null)
        {
            throw new Exception("User not found.");
        }

        await _context.UserRoles.Where(x => x.UserId == user.Id).ExecuteDeleteAsync();

        if(roles == null || !roles.Any())
        {
            return;
        }

        foreach (var role in roles)
        {
            await _userManager.AddToRoleAsync(user, role);
        }
    }
}
