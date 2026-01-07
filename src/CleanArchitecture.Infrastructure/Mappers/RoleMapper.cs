using CleanArchitecture.Application.Dtos.Roles;
using CleanArchitecture.Infrastructure.Identity;

namespace CleanArchitecture.Infrastructure.Mappers;

public static class RoleMapper
{
    public static RoleDto ToRoleDto(this ApplicationRole role)
    {
        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name
        };
    }

    public static IEnumerable<RoleDto> ToRoleDtos(this IEnumerable<ApplicationRole> roles)
    {
        var result = new List<RoleDto>();

        foreach (var role in roles)
        {
            result.Add(role.ToRoleDto());
        }

        return result;
    }
}
