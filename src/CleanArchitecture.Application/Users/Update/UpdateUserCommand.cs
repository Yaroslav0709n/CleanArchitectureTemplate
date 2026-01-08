using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Users.Update;

public class UpdateUserCommand : ICommand<Guid>
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<string>? Roles { get; set; }
}
