using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Dtos.Roles;

namespace CleanArchitecture.Application.Organizations.Update;

public class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand, Guid>
{
    private readonly IRoleService _roleService;

    public UpdateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<Guid> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
    {
        var roleId = await _roleService.UpdateAsync(new UpdateRoleRequest
                                                    {
                                                        Id = command.Id,
                                                        Name = command.Name
                                                    }, cancellationToken);

        return roleId;
    }
}