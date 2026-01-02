using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Mappers;
using CleanArchitecture.Application.Organizations.Dto;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Organizations.Get;

internal sealed class GetOrganizationsQueryHandler : IQueryHandler<GetOrganizationsQuery, IEnumerable<OrganizationResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetOrganizationsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrganizationResponse>> Handle(GetOrganizationsQuery query, CancellationToken cancellationToken)
    {
        var organizations = await _context.Organizations.ToListAsync(cancellationToken);

        return organizations.ToOrganizationResponseList();
    }
}
