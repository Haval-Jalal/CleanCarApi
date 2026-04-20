using CleanCarApi.Application.Auth;
using FluentValidation;

namespace CleanCarApi.Application.Auth.Validators;

public class LoginValidator : AbstractValidator<LoginCommand>
{
    public LoginValidator()
    {
        RuleFor(x => x.Dto.Username)
            .NotEmpty().WithMessage("Username är obligatoriskt");

        RuleFor(x => x.Dto.Password)
            .NotEmpty().WithMessage("Password är obligatoriskt");
    }
}
