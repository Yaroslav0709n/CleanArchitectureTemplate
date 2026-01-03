namespace CleanArchitecture.Application.Dtos.Tokens;

public class CreateTokenRequest
{
    public Guid UserId { get; set; }
    public string UserEmail { get; set; }
}
