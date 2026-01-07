using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Roles.Create;

public class CreateRoleCommand : ICommand
{
    public string Name { get; set; }
}