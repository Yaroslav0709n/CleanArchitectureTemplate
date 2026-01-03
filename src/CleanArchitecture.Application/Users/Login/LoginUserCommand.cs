using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Users.Login;

public class LoginUserCommand : ICommand<string>
{
    public string Email { get; set; }
    public string Password { get; set; }
}