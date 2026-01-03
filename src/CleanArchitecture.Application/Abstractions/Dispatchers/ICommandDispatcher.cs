using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Abstractions.Dispatchers;

public interface ICommandDispatcher
{
    Task<TResponse> Dispatch<TCommand, TResponse>(TCommand command, CancellationToken cancellation)
        where TCommand : ICommand<TResponse>;

    Task Dispatch<TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : ICommand;
}