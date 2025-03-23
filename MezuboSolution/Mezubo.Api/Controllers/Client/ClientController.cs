

namespace Mezubo.Api.Controllers.Client
{
    using ErrorOr;
    using MediatR;
    using Mezubo.Api.Controllers.Base;
    using Mezubo.Application.Features.Client.Commands.Create;
    using Mezubo.Domain.Resources;
    using Microsoft.AspNetCore.Mvc;

    public class ClientController : BaseController
    {
        private readonly ISender _sender;
        public ClientController(IConfiguration configuration, ISender sender) : base(configuration)
        {
            this._sender = sender;
        }

        /// <summary>
        /// Metodo encargado de recibir el Json de Creación de cliente
        /// </summary>
        /// <param name="request"></param>
        /// <returns><see cref="CreateClientResponse"/></returns>
        [HttpPost("CreateClient")]
        [ProducesResponseType(typeof(CreateClientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesErrorResponseType(typeof(string))]
        public async Task<IActionResult> CreateClient(CreateClientRequest request)
        {
            try
            {
                ErrorOr<CreateClientResponse> response = await this._sender.Send(request);
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
