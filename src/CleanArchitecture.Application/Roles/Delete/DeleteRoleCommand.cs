using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Roles.Delete;

public class DeleteRoleCommand : ICommand
{
    public Guid Id { get; set; }

    public DeleteRoleCommand(Guid id)
    {
        Id = id;
    }
}