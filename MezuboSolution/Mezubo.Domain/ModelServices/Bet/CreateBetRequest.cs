namespace Mezubo.Domain.ModelServices.Bet
{
    using ErrorOr;
    using MediatR;

    public class CreateBetRequest : BetDto, IRequest<ErrorOr<CreateBetResponse>>
    {
        public int ClientId { get; set; }
    }
}
