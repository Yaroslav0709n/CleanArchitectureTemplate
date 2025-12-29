using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Users.Dto;
using CleanArchitecture.Application.Users.GetByEmail;

namespace CleanArchitecture.Application.Users.GetByEmailAsync;

internal sealed class GetUserByEmailQueryHandler : IQueryHandler<GetUserByEmailQuery, UserResponse>
{
    private readonly IIdentityService _identityService;

    public GetUserByEmailQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<UserResponse> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
    {
        return await _identityService.GetByEmailAsync(query.Email, cancellationToken);
    }
}
