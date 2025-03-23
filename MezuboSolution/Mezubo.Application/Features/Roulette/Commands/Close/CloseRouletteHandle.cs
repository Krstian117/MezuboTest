namespace Mezubo.Application.Features.Roulette.Commands.Close
{
    using ErrorOr;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CloseRouletteHandle : IRequestHandler<CloseRouletteRequest, ErrorOr<CloseRouletteResponse>>
    {
        public async Task<ErrorOr<CloseRouletteResponse>> Handle(CloseRouletteRequest request, CancellationToken cancellationToken)
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
