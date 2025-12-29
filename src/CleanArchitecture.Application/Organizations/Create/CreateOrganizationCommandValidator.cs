using FluentValidation;

namespace CleanArchitecture.Application.Organizations.Create;

public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
{
    public CreateOrganizationCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Phone).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Fax).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Email).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Address.City).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Address.Street).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Address.HomeNumber).NotEmpty().MaximumLength(10);
        RuleFor(x => x.Address.ApartmentNumber).NotEmpty().MaximumLength(10);
        RuleFor(x => x.Address.ZipCode).NotEmpty().MaximumLength(10);
        RuleFor(x => x.Address.MailBox).NotEmpty().MaximumLength(10);
    }
}