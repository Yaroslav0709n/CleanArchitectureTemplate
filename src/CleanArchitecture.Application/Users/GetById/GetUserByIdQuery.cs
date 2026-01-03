using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Dtos.Users;

namespace CleanArchitecture.Application.Users.GetById;

public class GetUserByIdQuery : IQuery<UserResponse>
{
    public Guid Id { get; set; }
}