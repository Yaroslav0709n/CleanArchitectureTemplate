using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Roles.Delete;

public class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand>
{
    private readonly IRoleService _roleService;

    public DeleteRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
    {
        await _roleService.DeleteAsync(command.Id, cancellationToken);
    }
}