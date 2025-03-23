namespace Mezubo.Application.Features.Roulette.Commands.Open
{
    using ErrorOr;
    using MediatR;
    using Mezubo.Domain.Enums;
    using Mezubo.Domain.Persistence;
    using Mezubo.Domain.Resources;
    using System.Threading;
    using System.Threading.Tasks;

    public class OpenRouletteHandle : IRequestHandler<OpenRouletteRequest, ErrorOr<OpenRouletteResponse>>
    {
        private readonly IRouletteRepository _rouletteRepository;

        public OpenRouletteHandle(IRouletteRepository rouletteRepository)
        {
            this._rouletteRepository = rouletteRepository;
        }
        public async Task<ErrorOr<OpenRouletteResponse>> Handle(OpenRouletteRequest request, CancellationToken cancellationToken)
        {
            List<Error> errors = new List<Error>();
            try
            {
                OpenRouletteResponse response = new OpenRouletteResponse();
                ErrorOr<Success> existRoulette = await this._rouletteRepository.ValidateExistRoulette(request.RouletteId);
                if (existRoulette.IsError) errors.AddRange(existRoulette.Errors);
                else
                {
                    ErrorOr<Success> updateRoulette = await this._rouletteRepository.UpdateRoulette(request.RouletteId, EnumRoulette.OPEN);
                    if (updateRoulette.IsError) errors.AddRange(updateRoulette.Errors);
                    else
                    {
                        response.Id = request.RouletteId;
                        response.Message = string.Format(Messages.SuccessUpdateRoulette, request.RouletteId, "Abierta");
                    }
                }
                if (errors.Count > 0)
                {
                    return errors;
                }
                return response;
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
