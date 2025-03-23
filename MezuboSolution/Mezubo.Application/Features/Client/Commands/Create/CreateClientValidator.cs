namespace Mezubo.Application.Features.Client.Commands.Create
{
    using FluentValidation;
    using Mezubo.Domain.Resources;

    public class CreateClientValidator : AbstractValidator<CreateClientRequest>
    {
        public CreateClientValidator()
        {
            this.RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(string.Format(Messages.RequiredField, nameof(CreateClientRequest.Name)))
                .MaximumLength(200)
                .WithMessage(string.Format(Messages.MaxlenghtField, nameof(CreateClientRequest.Name), 200));

        }
    }
}
