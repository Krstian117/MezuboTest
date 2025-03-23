

namespace Mezubo.Api.Controllers.Roulette
{
    using ErrorOr;
    using MediatR;
    using Mezubo.Api.Controllers.Base;
    using Mezubo.Application.Features.Roulette.Commands.Create;
    using Mezubo.Domain.Resources;
    using Microsoft.AspNetCore.Mvc;

    public class RouletteController : BaseController
    {
        private readonly ISender _sender;
        public RouletteController(IConfiguration configuration, ISender sender) : base(configuration)
        {
            this._sender = sender;
        }

        /// <summary>
        /// Metodo encargado de crear ruletas
        /// </summary>
        /// <returns><see cref="CreateRouletteResponse"/></returns>
        [HttpPost("CreateRoulette")]
        [ProducesResponseType(typeof(CreateRouletteResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesErrorResponseType(typeof(string))]
        public async Task<IActionResult> CreateRoulette()
        {
            try
            {
                ErrorOr<CreateRouletteResponse> response = await this._sender.Send(new CreateRouletteRequest());
                if (response.IsError)
                {
                    string error = string.Empty;

                    List<string> failureErrors = response.Errors
                                          .Where(x => x.Type == ErrorType.Failure)
                                          .Select(x => x.Description)
                                          .ToList();

                    if (failureErrors.Count > 0)
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

