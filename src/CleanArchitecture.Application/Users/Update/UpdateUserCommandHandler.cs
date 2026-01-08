using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Dtos.Users;

namespace CleanArchitecture.Application.Users.Update;

public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, Guid>
{
    private readonly IIdentityService _identityService;
    private readonly IRoleService _roleService;

    public UpdateUserCommandHandler(IRoleService roleService, IIdentityService identityService)
    {
        _roleService = roleService;
        _identityService = identityService;
    }

    public async Task<Guid> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var userId = await _identityService.UpdateAsync(new UpdateUserRequest
                                                        {
                                                            Id = command.Id,
                                                            Email = command.Email,
                                                            FirstName = command.FirstName,
                                                            LastName = command.LastName
                                                        }, cancellationToken);

        await _roleService.AssignRolesAsync(userId, command.Roles, cancellationToken);

        return userId;
    }
}