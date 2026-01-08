using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Dtos.Roles;

namespace CleanArchitecture.Application.Roles.Create;

public class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand, Guid>
{
    private readonly IRoleService _roleService;

    public CreateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<Guid> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
    {
        var roleId = await _roleService.CreateAsync(new CreateRoleRequest
        {
            Name = command.Name
        });

        return roleId;
    }
}