using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Roles.Create;

public class CreateRoleCommand : ICommand<Guid>
{
    public string Name { get; set; }
}