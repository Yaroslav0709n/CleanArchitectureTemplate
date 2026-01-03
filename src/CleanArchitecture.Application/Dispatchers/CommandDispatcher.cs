using CleanArchitecture.Application.Abstractions.Dispatchers;
using CleanArchitecture.Application.Abstractions.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application.Dispatchers;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task<TResponse> Dispatch<TCommand, TResponse>(TCommand command, CancellationToken cancellation)
        where TCommand : ICommand<TResponse>
    {
        var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TResponse>>();

        return handler.Handle(command, cancellation);
    }

    public Task Dispatch<TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : ICommand
    {
        var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();

        return handler.Handle(command, cancellationToken);
    }
}