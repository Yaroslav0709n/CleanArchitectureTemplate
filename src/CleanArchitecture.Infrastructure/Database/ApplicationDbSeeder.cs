using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Common.Roles;
using CleanArchitecture.Infrastructure.Authentication;
using CleanArchitecture.Infrastructure.Authorization;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Database;

public class ApplicationDbSeeder : IApplicationDbSeeder
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly ApplicationDbContext _context;

    public ApplicationDbSeeder(RoleManager<ApplicationRole> roleManager, ApplicationDbContext context)
    {
        _roleManager = roleManager;
        _context = context;
    }

    public async Task SeedDatabaseAsync()
    {
        await SeedRolesAsync();
    }

    private async Task SeedRolesAsync()
    {
        foreach (string roleName in Roles.DefaultRoles)
        {
            if (await _roleManager.Roles.FirstOrDefaultAsync(r => r.Name == roleName) is not ApplicationRole role)
            {
                role = new ApplicationRole
                {
                    Name = roleName
                };

                await _roleManager.CreateAsync(role);
            }

            if (roleName == Roles.Basic)
            {
                await AssignPermissionsToRoleAsync(RolePermissions.Basic, role);
            }
            else
            {
                await AssignPermissionsToRoleAsync(RolePermissions.Admin, role);
            }
        }
    }

    private async Task AssignPermissionsToRoleAsync(IReadOnlyList<Permission> permissions, ApplicationRole role)
    {
        var currentClaims = await _roleManager.GetClaimsAsync(role);

        foreach (var permission in permissions)
        {
            if (currentClaims.Any(c => c.Type == Claims.Permission && c.Value == permission.Name))
            {
                continue;
            }

            await _context.RoleClaims.AddAsync(new ApplicationRoleClaim
            {
                RoleId = role.Id,
                ClaimType = Claims.Permission,
                ClaimValue = permission.Name
            });
            await _context.SaveChangesAsync();
        }
    }
}
