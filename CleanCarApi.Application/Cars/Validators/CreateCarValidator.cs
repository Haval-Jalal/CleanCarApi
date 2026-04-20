using CleanCarApi.Application.Cars.Commands;
using FluentValidation;

namespace CleanCarApi.Application.Cars.Validators;

public class CreateCarValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarValidator()
    {
        RuleFor(x => x.Dto.Model)
            .NotEmpty().WithMessage("Model är obligatoriskt")
            .MaximumLength(100).WithMessage("Model får max vara 100 tecken");

        RuleFor(x => x.Dto.Year)
            .InclusiveBetween(1886, DateTime.UtcNow.Year + 1)
            .WithMessage($"Year måste vara mellan 1886 och {DateTime.UtcNow.Year + 1}");

        RuleFor(x => x.Dto.Price)
            .GreaterThan(0).WithMessage("Price måste vara större än 0");

        RuleFor(x => x.Dto.BrandId)
            .GreaterThan(0).WithMessage("BrandId måste vara ett giltigt id");
    }
}
