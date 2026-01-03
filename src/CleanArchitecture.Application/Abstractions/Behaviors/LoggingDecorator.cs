using CleanArchitecture.Application.Abstractions.Messaging;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Abstractions.Behaviors;

public class LoggingDecorator
{
    public class CommandHandler<TCommand, TResponse>(ICommandHandler<TCommand, TResponse> innerHandler, ILogger<CommandHandler<TCommand, TResponse>> logger) : ICommandHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
        public async Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken)
        {
            string commandName = typeof(TCommand).Name;

            logger.LogInformation("Processing command {Command}", commandName);

            TResponse result = await innerHandler.Handle(command, cancellationToken);

            logger.LogInformation("Completed command {Command}", commandName);

            return result;
        }
    }

    public class CommandBaseHandler<TCommand>(ICommandHandler<TCommand> innerHandler, ILogger<CommandBaseHandler<TCommand>> logger) : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        public async Task Handle(TCommand command, CancellationToken cancellationToken)
        {
            string commandName = typeof(TCommand).Name;

            logger.LogInformation("Processing command {Command}", commandName);

            await innerHandler.Handle(command, cancellationToken);

            logger.LogInformation("Completed command {Command}", commandName);
        }
    }

    public class QueryHandler<TQuery, TResponse>(IQueryHandler<TQuery, TResponse> innerHandler, ILogger<QueryHandler<TQuery, TResponse>> logger) : IQueryHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        public async Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken)
        {
            string queryName = typeof(TQuery).Name;

            logger.LogInformation("Processing query {Query}", queryName);

            TResponse result = await innerHandler.Handle(query, cancellationToken);

            logger.LogInformation("Completed query {Query}", queryName);

            return result;
        }
    }
}
