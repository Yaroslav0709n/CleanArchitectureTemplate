using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Organizations.Update;

internal sealed class UpdateOrganizationCommandHandler : ICommandHandler<UpdateOrganizationCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdateOrganizationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UpdateOrganizationCommand command, CancellationToken cancellationToken)
    {
        var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

        if (organization == null)
        {
            throw new Exception("Organization not found.");
        }

        organization.Name = command.Name;
        organization.Phone = command.Phone;
        organization.Fax = command.Fax;
        organization.Email = command.Email;
        organization.Address.City = command.Address?.City;
        organization.Address.Street = command.Address?.Street;
        organization.Address.HomeNumber = command.Address?.HomeNumber;
        organization.Address.ApartmentNumber = command.Address?.ApartmentNumber;
        organization.Address.ZipCode = command.Address?.ZipCode;
        organization.Address.MailBox = command.Address?.MailBox;

        await _context.SaveChangesAsync(cancellationToken);

        return organization.Id;
    }
}
