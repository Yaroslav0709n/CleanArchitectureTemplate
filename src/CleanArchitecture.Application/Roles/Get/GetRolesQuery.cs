using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Dtos.Roles;

namespace CleanArchitecture.Application.Roles.Get;

public class GetRolesQuery : IQuery<IEnumerable<RoleDto>>
{
}
