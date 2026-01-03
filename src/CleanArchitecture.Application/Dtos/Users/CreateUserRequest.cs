namespace CleanArchitecture.Application.Dtos.Users;

public class CreateUserRequest
{
    public string Email { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Password { get; init; }
}