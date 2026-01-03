using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Dtos.Users;

namespace CleanArchitecture.Application.Users.Register;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
{
    private readonly IIdentityService _identityService;

    public RegisterUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        if (await _identityService.IsAnyByEmailAsync(command.Email, cancellationToken))
        {
            throw new Exception("User already exist by this email.");
        }

        var request = new CreateUserRequest
        {
            Email = command.Email,
            FirstName = command.FirstName,
            LastName = command.LastName,
            Password = command.Password
        };

        await _identityService.CreateAsync(request, cancellationToken);
    }
}
