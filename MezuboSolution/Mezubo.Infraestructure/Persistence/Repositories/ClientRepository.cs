namespace Mezubo.Infraestructure.Persistence.Repositories
{
    using ErrorOr;
    using Mezubo.Domain.Entities;
    using Mezubo.Domain.Persistence;
    using Mezubo.Domain.Resources;
    using Sistran.DataAccess.SqlBuilder;
    using Sistran.Extensions.Instrumentation.Enums;
    using System.Data;
    using System.Threading.Tasks;

    internal class ClientRepository : IClientRepository
    {
        private readonly IDbContext<DataProcessingMezubo> _dbContext;

        public ClientRepository(IDbContext<DataProcessingMezubo> dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<ErrorOr<Success>> ValidateExistClient(string Name)
        {
            try
            {
                using IDbContext db = this._dbContext.Open();
                string result = string.Empty;
                IQuery query = db.From<ClientEntity>()
                    .Where(x => x.Name == Name)
                    .Select(x => x.Name);
                result = (await db.QueryAsync<string>(query)).FirstOrDefault();
                if (string.IsNullOrEmpty(result))
                {
                    return Result.Success;//El cliente no existe
                }
                return Error.Failure(nameof(ValidateExistClient), string.Format(Messages.ExistClient, Name));
            }
            catch (Exception ex)
            {
                return Error.Unexpected(nameof(ValidateExistClient), ex.Message, new Dictionary<string, object>
                {
                     { nameof(Exception), ex}
                });
            }
        }

        public async Task<ErrorOr<Success>> CreateClient(string Name)
        {
            try
            {
                using IDbContext db = this._dbContext.Open();
                IQueryInsert query = db.Insert<ClientEntity>(_ => new ClientEntity
                {
                    Name = Name
                });
                await db.QueryAsync<ClientEntity>(query);
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Error.Unexpected(nameof(CreateClient), ex.Message, new Dictionary<string, object>
                {
                     { nameof(Exception), ex}
                });
            }
        }


    }
}
