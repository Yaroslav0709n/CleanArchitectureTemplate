using CleanArchitecture.Application.Abstractions.Messaging;
using FluentValidation;
using FluentValidation.Results;

namespace CleanArchitecture.Application.Abstractions.Behaviors;

public class ValidationDecorator
{
    public class CommandHandler<TCommand, TResponse>(ICommandHandler<TCommand, TResponse> innerHandler, IEnumerable<IValidator<TCommand>> validators) : ICommandHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
        public async Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken)
        {
            var validationFailures = await ValidateAsync(command, validators);

            if (validationFailures.Length != 0)
            {
                throw new ValidationException(validationFailures);
            }

            return await innerHandler.Handle(command, cancellationToken);
        }
    }

    public class CommandBaseHandler<TCommand>(ICommandHandler<TCommand> innerHandler, IEnumerable<IValidator<TCommand>> validators) : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        public async Task Handle(TCommand command, CancellationToken cancellationToken)
        {
            var validationFailures = await ValidateAsync(command, validators);

            if (validationFailures.Length != 0)
            {
                throw new ValidationException(validationFailures);
            }

            await innerHandler.Handle(command, cancellationToken);
        }
    }

    private static async Task<ValidationFailure[]> ValidateAsync<TCommand>(TCommand command, IEnumerable<IValidator<TCommand>> validators)
    {
        if (!validators.Any())
        {
            return [];
        }

        var context = new ValidationContext<TCommand>(command);

        var validationResults = await Task.WhenAll(validators.Select(validator => validator.ValidateAsync(context)));

        var validationFailures = validationResults.Where(validationResult => !validationResult.IsValid)
                                                  .SelectMany(validationResult => validationResult.Errors)
                                                  .ToArray();

        return validationFailures;
    }
}
