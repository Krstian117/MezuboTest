namespace Mezubo.Application.Features.Roulette.Commands.Create
{
    using ErrorOr;
    using MediatR;

    /// <summary>
    /// Clase utilizada para el proceso de crear una ruleta
    /// </summary>
    public class CreateRouletteRequest: IRequest<ErrorOr<CreateRouletteResponse>>
    {
    }
}
