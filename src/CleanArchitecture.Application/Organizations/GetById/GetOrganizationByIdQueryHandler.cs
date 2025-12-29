using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Addresses.Dto;
using CleanArchitecture.Application.Organizations.Dto;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Organizations.GetById;

internal sealed class GetOrganizationByIdQueryHandler : IQueryHandler<GetOrganizationByIdQuery, OrganizationResponse>
{
    private readonly IApplicationDbContext _context;

    public GetOrganizationByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OrganizationResponse> Handle(GetOrganizationByIdQuery query, CancellationToken cancellationToken)
    {
        var organization = await _context.Organizations.Select(x => new OrganizationResponse
                                                       {
                                                            Id = x.Id,
                                                            Name = x.Name,
                                                            Phone = x.Phone,
                                                            Fax = x.Fax,
                                                            Email = x.Email,
                                                            Address = new AddressResponse
                                                            {
                                                                City = x.Address.City,
                                                                Street = x.Address.Street,
                                                                HomeNumber = x.Address.HomeNumber,
                                                                ApartmentNumber = x.Address.ApartmentNumber,
                                                                ZipCode = x.Address.ZipCode,
                                                                MailBox = x.Address.MailBox
                                                            }
                                                       })
                                                       .FirstOrDefaultAsync(x => x.Id == query.Id);

        return organization;
    }
}
