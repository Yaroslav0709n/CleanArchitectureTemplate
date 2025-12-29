//using Application.Abstractions.Authentication;
//using Application.Abstractions.Data;
//using Application.Abstractions.Messaging;
//using CleanArchitecture.Application.Abstractions.Identity;
//using CleanArchitecture.Application.Abstractions.Messaging;
//using CleanArchitecture.Application.Exceptions;
//using Domain.Users;
//using Microsoft.EntityFrameworkCore;
//using SharedKernel;

//namespace Application.Users.Login;

//internal sealed class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, string>
//{
//    private readonly IIdentityService _identityService;

//    public LoginUserCommandHandler(IIdentityService identityService)
//    {
//        _identityService = identityService;
//    }

//    public async Task<string> Handle(LoginUserCommand command, CancellationToken cancellationToken)
//    {
//        var verified = await _identityService.CheckPasswordAsync(command.Email, command.Password, cancellationToken);

//        if (!verified)
//        {
//            throw new UnauthorizedException("Authentication failed.");
//        }

//        string token = tokenProvider.Create(user);

//        return token;
//    }
//}
