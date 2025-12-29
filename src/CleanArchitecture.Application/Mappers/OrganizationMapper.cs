using CleanArchitecture.Application.Organizations.Dto;
using CleanArchitecture.Domain.Organizations;

namespace CleanArchitecture.Application.Mappers;

public static class OrganizationMapper
{
    public static OrganizationResponse ToOrganizationResponse(this Organization organization)
    {
        return new OrganizationResponse
        {
            Id = organization.Id,
            Name = organization.Name,
            Phone = organization.Phone,
            Fax = organization.Fax,
            Email = organization.Email,
            Address = organization.Address?.ToAddressResponse()
        };
    }
}
