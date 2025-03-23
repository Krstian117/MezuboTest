namespace Mezubo.Application.Features.Client.Commands.Create
{
    using ErrorOr;
    using MediatR;
    using Mezubo.Domain.Persistence;
    using Mezubo.Domain.Resources;
    using System.Threading;

    public class CreateClientHandle : IRequestHandler<CreateClientRequest, ErrorOr<CreateClientResponse>>
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientHandle(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }
        public async Task<ErrorOr<CreateClientResponse>> Handle(CreateClientRequest request, CancellationToken cancellationToken)
        {
            List<Error> errors = new List<Error>();
            CreateClientResponse response = new CreateClientResponse();
            try
            {
                ErrorOr<Success> validateClient = await this._clientRepository.ValidateExistClient(request.Name);
                if (validateClient.IsError) errors.AddRange(validateClient.Errors);
                else
                {
                    ErrorOr<Success> result = await this._clientRepository.CreateClient(request.Name);
                    if (result.IsError) errors.AddRange(result.Errors);
                    else
                    {
                        response.Message = string.Format(Messages.SuccessCreation, Messages.Client, "o");
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
