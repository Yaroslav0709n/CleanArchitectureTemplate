using FluentValidation;

namespace CleanArchitecture.Application.Users.Register;

public class LoginUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
    }
}