namespace Mezubo.Application.Features.Roulette.Commands.Open
{
    using FluentValidation;
    using Mezubo.Domain.Resources;

    public class OpenRouletteValidator : AbstractValidator<OpenRouletteRequest>
    {
        public OpenRouletteValidator()
        {
            this.RuleFor(x => x.RouletteId)
               .NotEmpty()
               .WithMessage(string.Format(Messages.RequiredField, nameof(OpenRouletteRequest.RouletteId)))
               .GreaterThan(0)
               .WithMessage(string.Format(Messages.NumberGreaterThan, nameof(OpenRouletteRequest.RouletteId), 0));
        }
    }
}
