namespace Mezubo.Application.Features.Roulette.Commands.Close
{
    using FluentValidation;
    using Mezubo.Application.Features.Roulette.Commands.Open;
    using Mezubo.Domain.Resources;
    public class CloseRouletteValidator : AbstractValidator<CloseRouletteRequest>
    {
        public CloseRouletteValidator()
        {
            this.RuleFor(x => x.RouletteId)
               .NotEmpty()
               .WithMessage(string.Format(Messages.RequiredField, nameof(OpenRouletteRequest.RouletteId)))
               .GreaterThan(0)
               .WithMessage(string.Format(Messages.NumberGreaterThan, nameof(OpenRouletteRequest.RouletteId), 0));
        }

    }
}
