namespace CleanArchitecture.Application.Dtos.Users;

public class UpdateUserRequest
{
    public Guid Id { get; set; }
    public string Email { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
}