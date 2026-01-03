using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Dtos.Addresses;
using CleanArchitecture.Application.Mappers;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Organizations.GetById;

public class GetOrganizationByIdQueryHandler : IQueryHandler<GetOrganizationByIdQuery, OrganizationResponse>
{
    private readonly IApplicationDbContext _context;

    public GetOrganizationByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OrganizationResponse> Handle(GetOrganizationByIdQuery query, CancellationToken cancellationToken)
    {
        var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);

        return organization?.ToOrganizationResponse();
    }
}
