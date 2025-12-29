namespace CleanArchitecture.Application.Abstractions.CurrentUser;

public interface ICurrentUser
{
    Guid? GetUserId();
}