using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Organizations.Delete;

public sealed record DeleteOrganizationCommand(Guid Id) : ICommand;
