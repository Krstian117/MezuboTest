namespace Mezubo.Application.Features.Roulette.Commands.Close
{
    using ErrorOr;
    using MediatR;

    /// <summary>
    /// Clase utilizada para el proceso de cerrar una ruleta
    /// </summary>
    public class CloseRouletteRequest: IRequest<ErrorOr<CloseRouletteResponse>>
    {
    }
}
