

namespace Mezubo.Api.Controllers.Client
{
    using ErrorOr;
    using MediatR;
    using Mezubo.Api.Controllers.Base;
    using Mezubo.Application.Features.Client.Commands.Create;
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
        /// <param name="client"></param>
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
                    if (response.Errors.Any(x => x.Type == ErrorType.Validation))
                    {
                        string error = string.Join(", ", response.Errors.Where(x => x.Type == ErrorType.Validation).Select(x => x.Description));
                        return this.BadRequest(error);
                    }
                    return this.BadRequest(string.Join(", ", response.Errors.Select(z => z.Description)));
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
