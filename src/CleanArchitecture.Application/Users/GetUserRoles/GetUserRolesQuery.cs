using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Dtos.Roles;

namespace CleanArchitecture.Application.Users.GetByEmail;

public class GetUserRolesQuery : IQuery<IEnumerable<string>>
{
    public Guid Id { get; set; }

    public GetUserRolesQuery(Guid id)
    {
        Id = id;
    }
}