using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Organizations.Dto;

namespace CleanArchitecture.Application.Organizations.Get;

public sealed record GetOrganizationsQuery() : IQuery<List<OrganizationResponse>>;
