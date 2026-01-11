using CleanArchitecture.Domain.Events;

namespace CleanArchitecture.Application.Abstractions.Events;

public interface IDomainEventHandler<in T> where T : IDomainEvent
{
    Task Handle(T domainEvent, CancellationToken cancellationToken);
}