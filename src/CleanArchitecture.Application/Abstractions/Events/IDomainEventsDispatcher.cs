using CleanArchitecture.Domain.Events;

namespace CleanArchitecture.Application.Abstractions.Events;

public interface IDomainEventsDispatcher
{
    Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken = default);
}
