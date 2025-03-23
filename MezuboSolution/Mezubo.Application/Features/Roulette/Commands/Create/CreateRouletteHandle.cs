namespace Mezubo.Application.Features.Roulette.Commands.Create
{
    using ErrorOr;
    using MediatR;
    using Mezubo.Domain.Persistence;
    using Mezubo.Domain.Resources;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateRouletteHandle : IRequestHandler<CreateRouletteRequest, ErrorOr<CreateRouletteResponse>>
    {
        private readonly IRouletteRepository _rouletteRepository;

        public CreateRouletteHandle(IRouletteRepository rouletteRepository)
        {
            this._rouletteRepository = rouletteRepository;
        }

        public async Task<ErrorOr<CreateRouletteResponse>> Handle(CreateRouletteRequest request, CancellationToken cancellationToken)
        {
            List<Error> errors = new List<Error>();
            CreateRouletteResponse response = new CreateRouletteResponse();
            try
            {
                ErrorOr<int> createRoulette = await this._rouletteRepository.CreateRoulette();
                if (createRoulette.IsError) errors.AddRange(createRoulette.Errors);
                else
                {
                    response.Id = createRoulette.Value;
                    response.Message = string.Format(Messages.SuccessCreation, Messages.Roulette, "a");
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
