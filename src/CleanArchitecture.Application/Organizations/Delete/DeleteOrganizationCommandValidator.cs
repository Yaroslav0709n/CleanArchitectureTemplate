using FluentValidation;

namespace CleanArchitecture.Application.Organizations.Delete;

internal sealed class DeleteOrganizationCommandValidator : AbstractValidator<DeleteOrganizationCommand>
{
    public DeleteOrganizationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
