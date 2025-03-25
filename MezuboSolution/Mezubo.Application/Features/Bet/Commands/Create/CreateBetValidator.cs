namespace Mezubo.Application.Features.Bet.Commands.Create
{
    using FluentValidation;
    using Mezubo.Domain.Constanst;
    using Mezubo.Domain.Enums;
    using Mezubo.Domain.ModelServices.Bet;
    using Mezubo.Domain.Resources;
    using Microsoft.Extensions.Configuration;

    public class CreateBetValidator : AbstractValidator<CreateBetRequest>
    {
        private readonly decimal _maxValueToBet;

        public CreateBetValidator(IConfiguration configuration)
        {
            this._maxValueToBet = configuration.GetValue<decimal>("AppKeys:maxValueToBet");

            this.RuleFor(b => b.ClientId)
               .NotEmpty()
               .WithMessage(string.Format(Messages.RequiredField, nameof(CreateBetRequest.ClientId)))
               .GreaterThan(0)
               .WithMessage(string.Format(Messages.NumberGreaterThan, nameof(CreateBetRequest.ClientId), 0));

            this.RuleFor(b => b.RouletteId)
                .NotEmpty()
                .WithMessage(string.Format(Messages.RequiredField, nameof(CreateBetRequest.RouletteId)))
                .GreaterThan(0)
                .WithMessage(string.Format(Messages.NumberGreaterThan, nameof(CreateBetRequest.RouletteId), 0));

            this.RuleFor(b => b.BetType)
                .NotEmpty()
                .WithMessage(string.Format(Messages.RequiredField, nameof(CreateBetRequest.BetType)))
                .MaximumLength(1)
                .WithMessage(string.Format(Messages.MaxlenghtField, nameof(CreateBetRequest.BetType), 1))
                .Matches(GenericConstants.ValidateBetType)
                .WithMessage(string.Format(Messages.ErrorRegularExpression, nameof(CreateBetRequest.BetType), "C, c, N, n"));

            this.RuleFor(b => b.BetValue)
                .NotEmpty()
                .WithMessage(string.Format(Messages.RequiredField, nameof(CreateBetRequest.BetValue)))
                .Must((bet, value) =>
                    {
                        if (bet.BetType.ToUpper() == BetType.N.ToString())
                            return int.TryParse(value, out int num) && num >= 0 && num <= 36;
                        if (bet.BetType.ToUpper() == BetType.C.ToString())
                            return value.ToUpper() == AvalaibleColor.B.ToString() || value == AvalaibleColor.R.ToString();
                        return false;
                    })
                .WithMessage("El objetivo de la apuesta debe ser un número entre 0 y 36 o 'Red'/'Black'.");

            this.RuleFor(b => b.Amount)
                .NotEmpty()
                .WithMessage(string.Format(Messages.RequiredField, nameof(CreateBetRequest.Amount)))
                .GreaterThan(0)
                .WithMessage(string.Format(Messages.NumberGreaterThan, nameof(CreateBetRequest.Amount), 0))
                .LessThanOrEqualTo(this._maxValueToBet).WithMessage("El valor máximo permitido es " + this._maxValueToBet);
        }
    }
}
