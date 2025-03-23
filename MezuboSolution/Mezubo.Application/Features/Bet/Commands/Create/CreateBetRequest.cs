namespace Mezubo.Application.Features.Bet.Commands.Create
{
    using ErrorOr;
    using MediatR;

    public class CreateBetRequest: IRequest<ErrorOr<CreateBetResponse>>
    {
    }
}
