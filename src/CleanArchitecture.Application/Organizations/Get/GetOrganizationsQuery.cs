using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Dtos.Addresses;

namespace CleanArchitecture.Application.Organizations.Get;

public class GetOrganizationsQuery : IQuery<IEnumerable<OrganizationResponse>>
{
}
