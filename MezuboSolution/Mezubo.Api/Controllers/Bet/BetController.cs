
namespace Mezubo.Api.Controllers.Bet
{
    using AutoMapper;
    using ErrorOr;
    using MediatR;
    using Mezubo.Api.Controllers.Base;
    using Mezubo.Application.Features.Client.Commands.Create;
    using Mezubo.Domain.ModelServices.Bet;
    using Mezubo.Domain.Resources;
    using Microsoft.AspNetCore.Mvc;

    public class BetController : BaseController
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        public BetController(IConfiguration configuration, ISender sender, IMapper mapper) : base(configuration)
        {
            this._sender = sender;
            this._mapper = mapper;
        }

        /// <summary>
        /// Metodo encargado de recibir el Json de Creación de cliente
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="bet"></param>
        /// <returns></returns>
        [HttpPost("CreateBet")]
        [ProducesResponseType(typeof(CreateBetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesErrorResponseType(typeof(string))]
        public async Task<IActionResult> CreateBet([FromHeader(Name = "UserId")] int UserId, BetDto bet)
        {
            try
            {
                CreateBetRequest request = this._mapper.Map<CreateBetRequest>(bet);
                request.ClientId = UserId;
                ErrorOr<CreateBetResponse> response = await this._sender.Send(request);
                if (response.IsError)
                {
                    string error = string.Empty;
                    List<string> validationErrors = response.Errors
                                           .Where(x => x.Type == ErrorType.Validation)
                                           .Select(x => x.Description)
                                           .ToList();

                    List<string> failureErrors = response.Errors
                                          .Where(x => x.Type == ErrorType.Failure)
                                          .Select(x => x.Description)
                                          .ToList();

                    if (validationErrors.Count > 0)
                    {
                        error = string.Join(", ", response.Errors.Where(x => x.Type == ErrorType.Validation).Select(x => x.Description));
                        return this.BadRequest(error);
                    }
                    else if (failureErrors.Count > 0)
                    {
                        error = string.Join(", ", response.Errors.Where(x => x.Type == ErrorType.Failure).Select(x => x.Description));
                        return this.Ok(error);
                    }
                    return this.Problem(Messages.InternalError);
                }
                return this.Ok(response.Value);
            }
            catch (Exception ex)
            {
                return this.Problem(ex.Message);
            }
        }
    }
}
