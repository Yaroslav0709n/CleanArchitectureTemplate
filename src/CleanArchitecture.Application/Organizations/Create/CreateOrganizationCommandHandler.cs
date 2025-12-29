using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Addresses;
using CleanArchitecture.Domain.Organizations;

namespace CleanArchitecture.Application.Organizations.Create;

internal sealed class CreateOrganizationCommandHandler : ICommandHandler<CreateOrganizationCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateOrganizationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateOrganizationCommand command, CancellationToken cancellationToken)
    {
        var organization = new Organization
        {
            Name = command.Name,
            Phone = command.Phone,
            Fax = command.Fax,
            Email = command.Email,
            Address = new Address
            {
                City = command.Address?.City,
                Street = command.Address?.Street,
                HomeNumber = command.Address?.HomeNumber,
                ApartmentNumber = command.Address?.ApartmentNumber,
                ZipCode = command.Address?.ZipCode,
                MailBox = command.Address?.MailBox
            }
        };

        await _context.Organizations.AddAsync(organization);
        await _context.SaveChangesAsync(cancellationToken);

        return organization.Id;
    }
}
