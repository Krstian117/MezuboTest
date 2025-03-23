namespace Mezubo.Application.Features.Roulette.Commands.Open
{
    using ErrorOr;
    using MediatR;

    /// <summary>
    /// Clase utilizada para el proceso de abrir una ruleta
    /// </summary>
    public class OpenRouletteRequest : IRequest<ErrorOr<OpenRouletteResponse>>
    {
    }
}
