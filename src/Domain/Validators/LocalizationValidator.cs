using Domain.Entities;
using FluentValidation;


namespace Domain.Validators
{
    public class LocalizationValidator : AbstractValidator<Localization>
    {
        public LocalizationValidator()
        {
            RuleFor(location => location.Latitude)
                .NotEmpty().WithMessage("A latitude é obrigatória.")
                .InclusiveBetween(-90, 90).WithMessage("A latitude deve estar entre -90 e 90.");

            RuleFor(location => location.Longitude)
                .NotEmpty().WithMessage("A longitude é obrigatória.")
                .InclusiveBetween(-180, 180).WithMessage("A longitude deve estar entre -180 e 180.");
        }

    }
}