using CleanArchitecture.Application.Dtos.Users;

namespace CleanArchitecture.Application.Abstractions.Identity;

public interface IIdentityService
{
    Task<UserResponse> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<UserResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> CheckPasswordAsync(string email, string password, CancellationToken cancellationToken);
    Task<bool> IsAnyByEmailAsync(string email, CancellationToken cancellationToken);
    Task<Guid> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken);
    Task<Guid> UpdateAsync(UpdateUserRequest request, CancellationToken cancellationToken);
    Task<bool> HasPermissionAsync(Guid userId, string permission);
    Task<List<string>> GetPermissionsAsync(Guid userId);
    Task<IEnumerable<string>> GetRolesAsync(Guid userId, CancellationToken cancellationToken);
}