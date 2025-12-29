using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Organizations.Dto;

namespace CleanArchitecture.Application.Organizations.GetById;

public sealed record GetOrganizationByIdQuery(Guid Id) : IQuery<OrganizationResponse>;
