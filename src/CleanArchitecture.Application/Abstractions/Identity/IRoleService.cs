using CleanArchitecture.Application.Dtos.Roles;
namespace CleanArchitecture.Application.Abstractions.Identity;

public interface IRoleService
{
    Task<RoleDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<RoleDto>> GetListAsync(CancellationToken cancellationToken);
    Task<Guid> CreateAsync(CreateRoleRequest request);
    Task<Guid> UpdateAsync(UpdateRoleRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task AssignRolesAsync(Guid userId, IEnumerable<string> roles, CancellationToken cancellationToken);
}