namespace Mezubo.Application.Features.Bet.Commands.Create
{
    using ErrorOr;
    using MediatR;
    using Mezubo.Domain.ModelServices.Bet;
    using Mezubo.Domain.Persistence;
    using Mezubo.Domain.Resources;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateBetHandle : IRequestHandler<CreateBetRequest, ErrorOr<CreateBetResponse>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IRouletteRepository _rouletteRepository;
        private readonly IBetRepository _betRepository;


        public CreateBetHandle(IClientRepository clientRepository, IRouletteRepository rouletteRepository, IBetRepository betRepository)
        {
            this._clientRepository = clientRepository;
            this._rouletteRepository = rouletteRepository;
            this._betRepository = betRepository;
        }

        public async Task<ErrorOr<CreateBetResponse>> Handle(CreateBetRequest request, CancellationToken cancellationToken)
        {
            List<Error> errors = new List<Error>();
            try
            {
                CreateBetResponse response = new CreateBetResponse();
                ErrorOr<Success> validations = await this.Validations(request);
                if (validations.IsError) errors.AddRange(validations.Errors);
                else
                {
                    ErrorOr<Success> createBet = await this._betRepository.CreateBet(request);
                    if (createBet.IsError) errors.AddRange(createBet.Errors);
                    else
                    {
                        response.Message = string.Format(Messages.SuccessCreation, "Apuesta", "a");
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

        /// <summary>
        /// Metodo encargado de realizar validaciones
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<ErrorOr<Success>> Validations(CreateBetRequest request)
        {
            List<Error> errors = new List<Error>();
            List<Task> ListTask = new List<Task>();
            try
            {
                ListTask.Add(Task.Run(async () =>
                {
                    ErrorOr<Success> validateExistClient = await this._clientRepository.ValidateExistClient(request.ClientId);
                    if (validateExistClient.IsError) errors.AddRange(validateExistClient.Errors);
                }));
                ListTask.Add(Task.Run(async () =>
                {
                    ErrorOr<Success> validateExistRoulette = await this._rouletteRepository.ValidateExistRoulette(request.RouletteId);
                    if (validateExistRoulette.IsError) errors.AddRange(validateExistRoulette.Errors);
                    else
                    {
                        ErrorOr<Success> validateExistBet = await this._betRepository.ValidateSameBet(request);
                        if (validateExistBet.IsError) errors.AddRange(validateExistBet.Errors);
                    }
                }));

                await Task.WhenAll(ListTask);
                if (errors.Count > 0)
                {
                    return errors;
                }
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Error.Unexpected(nameof(Validations), ex.Message, new Dictionary<string, object>
                {
                    { nameof(Exception), ex }
                });
            }
        }
    }
}
