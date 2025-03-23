namespace Mezubo.Application.Features.Roulette.Commands.Open
{
    using ErrorOr;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class OpenRouletteHandle : IRequestHandler<OpenRouletteRequest, ErrorOr<OpenRouletteResponse>>
    {
        public async Task<ErrorOr<OpenRouletteResponse>> Handle(OpenRouletteRequest request, CancellationToken cancellationToken)
        {
            List<Error> errors = new List<Error>();
            try
            {
                return errors;
            }
            catch (Exception ex)
            {
                return Error.Unexpected(nameof(Handle), ex.Message, new Dictionary<string, object>
                {
                    { nameof(Exception), ex }
                });
            }
        }
    }
}
