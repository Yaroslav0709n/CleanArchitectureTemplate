using CleanArchitecture.Application.Organizations.Update;
using FluentValidation;

namespace CleanArchitecture.Application.Organizations.Create;

public class UpdateOrganizationCommandValidator : AbstractValidator<UpdateOrganizationCommand>
{
    public UpdateOrganizationCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Phone).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Fax).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Email).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Address.City).MaximumLength(50);
        RuleFor(x => x.Address.Street).MaximumLength(50);
        RuleFor(x => x.Address.HomeNumber).MaximumLength(10);
        RuleFor(x => x.Address.ApartmentNumber).MaximumLength(10);
        RuleFor(x => x.Address.ZipCode).MaximumLength(10);
        RuleFor(x => x.Address.MailBox).MaximumLength(10);
    }
}