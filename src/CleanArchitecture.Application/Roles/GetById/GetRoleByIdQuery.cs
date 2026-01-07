using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Dtos.Roles;

namespace CleanArchitecture.Application.Roles.GetById;

public class GetRoleByIdQuery : IQuery<RoleDto>
{
    public Guid Id { get; set; }

    public GetRoleByIdQuery(Guid id)
    {
        Id = id;
    }
}
