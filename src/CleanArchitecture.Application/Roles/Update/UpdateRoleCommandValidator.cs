using CleanArchitecture.Application.Organizations.Update;
using FluentValidation;

namespace CleanArchitecture.Application.Organizations.Create;

public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(256);
    }
}