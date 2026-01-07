using CleanArchitecture.Application.Dtos.Roles;
namespace CleanArchitecture.Application.Abstractions.Identity;

public interface IRoleService
{
    Task<RoleDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<RoleDto>> GetAsync(CancellationToken cancellationToken);
    Task CreateAsync(CreateRoleRequest request);
    Task UpdateAsync(UpdateRoleRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task AssignRolesAsync(Guid userId, IEnumerable<UserRoleDto> roles, CancellationToken cancellationToken);
}
