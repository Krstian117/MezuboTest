namespace Mezubo.Application.Features.Client.Commands.Create
{
    using ErrorOr;
    using MediatR;
    using System.Threading;

    public class CreateClientHandle : IRequestHandler<CreateClientRequest, ErrorOr<CreateClientResponse>>
    {
        public async Task<ErrorOr<CreateClientResponse>> Handle(CreateClientRequest request, CancellationToken cancellationToken)
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
