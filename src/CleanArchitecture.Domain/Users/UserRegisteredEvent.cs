using CleanArchitecture.Domain.Events;

namespace CleanArchitecture.Domain.Users;

public class UserRegisteredEvent : IDomainEvent
{
    public Guid UserId { get; }
    public DateTime Timestamp { get; } = DateTime.UtcNow;

    public UserRegisteredEvent(Guid userId)
    {
        UserId = userId;
    }
}