using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Dtos.Addresses;

namespace CleanArchitecture.Application.Organizations.GetById;

public class GetOrganizationByIdQuery : IQuery<OrganizationResponse>
{
    public Guid Id { get; set; }

    public GetOrganizationByIdQuery(Guid id)
    {
        Id = id;
    }
}
