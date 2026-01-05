using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Abstractions.Token;
using CleanArchitecture.Application.Dtos.Tokens;
using CleanArchitecture.Application.Exceptions;

namespace CleanArchitecture.Application.Users.Login;

public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, string>
{
    private readonly IIdentityService _identityService;
    private readonly ITokenProvider _tokenProvider;

    public LoginUserCommandHandler(IIdentityService identityService, ITokenProvider tokenProvider)
    {
        _identityService = identityService;
        _tokenProvider = tokenProvider;
    }

    public async Task<string> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _identityService.GetByEmailAsync(command.Email, cancellationToken);

        if (user == null)
        {
            throw new UnauthorizedException("Authentication failed.");
        }

        var verified = await _identityService.CheckPasswordAsync(command.Email, command.Password, cancellationToken);

        if (!verified)
        {
            throw new UnauthorizedException("Authentication failed.");
        }

        var token = await _tokenProvider.Create(new CreateTokenRequest
        {
            UserId = user.Id,
            UserEmail = user.Email,
        });

        return token;
    }
}
