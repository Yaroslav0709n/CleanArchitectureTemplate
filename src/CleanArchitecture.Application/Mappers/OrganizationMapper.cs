using CleanArchitecture.Application.Dtos.Addresses;
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
            Address = organization.Address?.ToAddressDto()
        };
    }

    public static IEnumerable<OrganizationResponse> ToOrganizationResponseList(this IEnumerable<Organization> organizations)
    {
        var result = new List<OrganizationResponse>();

        foreach (var organization in organizations)
        {
            result.Add(organization.ToOrganizationResponse());
        }

        return result;
    }
}
