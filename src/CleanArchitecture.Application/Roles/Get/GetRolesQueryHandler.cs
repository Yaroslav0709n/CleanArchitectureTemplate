using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Dtos.Roles;

namespace CleanArchitecture.Application.Roles.Get;

public class GetRolesQueryHandler : IQueryHandler<GetRolesQuery, IEnumerable<RoleDto>>
{
    private readonly IRoleService _roleService;

    public GetRolesQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<IEnumerable<RoleDto>> Handle(GetRolesQuery query, CancellationToken cancellationToken)
    {
        return await _roleService.GetListAsync(cancellationToken);
    }
}