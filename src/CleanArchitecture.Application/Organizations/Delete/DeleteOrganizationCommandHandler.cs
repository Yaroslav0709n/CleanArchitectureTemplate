using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Organizations.Delete;

internal sealed class DeleteOrganizationCommandHandler : ICommandHandler<DeleteOrganizationCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteOrganizationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteOrganizationCommand command, CancellationToken cancellationToken)
    {
        var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

        if (organization == null)
        {
            throw new Exception("Organization not found.");
        }

        _context.Organizations.Remove(organization);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
