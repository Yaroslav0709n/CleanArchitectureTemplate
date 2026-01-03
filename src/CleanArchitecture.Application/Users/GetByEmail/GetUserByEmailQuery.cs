using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Dtos.Users;

namespace CleanArchitecture.Application.Users.GetByEmail;

public class GetUserByEmailQuery : IQuery<UserResponse>
{
    public string Email { get; set; }

    public GetUserByEmailQuery(string email)
    {
        Email = email;
    }
}