namespace Mezubo.Application.Features.Bet.Commands.Create
{
    using ErrorOr;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateBetHandle : IRequestHandler<CreateBetRequest, ErrorOr<CreateBetResponse>>
    {
        public async Task<ErrorOr<CreateBetResponse>> Handle(CreateBetRequest request, CancellationToken cancellationToken)
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
