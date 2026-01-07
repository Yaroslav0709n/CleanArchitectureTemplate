using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Organizations.Update;

public class UpdateRoleCommand : ICommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
