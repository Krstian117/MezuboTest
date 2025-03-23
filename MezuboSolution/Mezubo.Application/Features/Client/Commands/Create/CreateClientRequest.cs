namespace Mezubo.Application.Features.Client.Commands.Create
{
    using ErrorOr;
    using MediatR;
    using Mezubo.Domain.ModelServices;

    /// <summary>
    /// Clase utilizada para la creación de un cliente
    /// </summary>
    public class CreateClientRequest : ClientDto, IRequest<ErrorOr<CreateClientResponse>>
    {

    }
}
