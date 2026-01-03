using CleanArchitecture.Application.Abstractions.Identity;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Dtos.Users;

namespace CleanArchitecture.Application.Users.GetById;

internal sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserResponse>
{
    private readonly IIdentityService _identityService;

    public GetUserByIdQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<UserResponse> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        return await _identityService.GetByIdAsync(query.Id, cancellationToken);
    }
}
