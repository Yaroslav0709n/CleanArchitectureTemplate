using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Dtos.Roles;

namespace CleanArchitecture.Application.Organizations.Update;

public class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand>
{
    private readonly IRoleService _roleService;

    public UpdateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
    {
        await _roleService.UpdateAsync(new UpdateRoleRequest
        {
            Id = command.Id,
            Name = command.Name
        }, cancellationToken);
    }
}