using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Users.GetByEmail;

namespace CleanArchitecture.Application.Users.GetByEmailAsync;

internal sealed class GetUserRolesQueryHandler : IQueryHandler<GetUserRolesQuery, IEnumerable<string>>
{
    private readonly IIdentityService _identityService;

    public GetUserRolesQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<IEnumerable<string>> Handle(GetUserRolesQuery query, CancellationToken cancellationToken)
    {
        return await _identityService.GetRolesAsync(query.Id, cancellationToken);
    }
}
