using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Dtos.Roles;

namespace CleanArchitecture.Application.Roles.Create;

public class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand>
{
    private readonly IRoleService _roleService;

    public CreateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task Handle(CreateRoleCommand command, CancellationToken cancellationToken)
    {
        await _roleService.CreateAsync(new CreateRoleRequest
        {
            Name = command.Name
        });
    }
}