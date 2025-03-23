namespace Mezubo.Application.Features.Roulette.Commands.Create
{
    using ErrorOr;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateRouletteHanlde : IRequestHandler<CreateRouletteRequest, ErrorOr<CreateRouletteResponse>>
    {
        public async Task<ErrorOr<CreateRouletteResponse>> Handle(CreateRouletteRequest request, CancellationToken cancellationToken)
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
