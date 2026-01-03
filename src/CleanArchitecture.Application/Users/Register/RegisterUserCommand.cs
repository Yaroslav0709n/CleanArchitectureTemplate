using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Users.Register;

public class RegisterUserCommand : ICommand
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}