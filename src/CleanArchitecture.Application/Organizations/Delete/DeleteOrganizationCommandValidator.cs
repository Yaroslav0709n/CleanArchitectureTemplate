using FluentValidation;

namespace CleanArchitecture.Application.Organizations.Delete;

public class DeleteOrganizationCommandValidator : AbstractValidator<DeleteOrganizationCommand>
{
    public DeleteOrganizationCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
