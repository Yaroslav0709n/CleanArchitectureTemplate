using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Organizations.Delete;

public class DeleteOrganizationCommand : ICommand
{
    public Guid Id { get; set; }

    public DeleteOrganizationCommand(Guid id)
    {
        Id = id;
    }
}