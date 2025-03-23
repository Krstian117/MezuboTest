namespace Mezubo.Infraestructure.Persistence.Repositories
{
    using ErrorOr;
    using Mezubo.Domain.Entities;
    using Mezubo.Domain.Enums;
    using Mezubo.Domain.Persistence;
    using Sistran.DataAccess.SqlBuilder;
    using System;
    using System.Threading.Tasks;

    internal class RouletteRepository : IRouletteRepository
    {
        private readonly IDbContext<DataProcessingMezubo> _dbContext;

        public RouletteRepository(IDbContext<DataProcessingMezubo> dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<ErrorOr<int>> CreateRoulette()
        {
            try
            {
                using IDbContext db = this._dbContext.Open();
                IQueryInsert query = db.Insert<RouletteEntity>(_ => new RouletteEntity
                {
                    CreationDate = DateTime.Now,
                    Status = EnumRoulette.OPEN.ToString()
                });
                int? identity = (await db.ExecuteScalarAsync<int?>(query));
                if (identity.HasValue)
                {
                    return (int)identity;
                }
                else
                {
                    return Error.Failure(nameof(CreateRoulette), "Error al crear Ruleta");
                }
            }
            catch (Exception ex)
            {
                return Error.Unexpected(nameof(CreateRoulette), ex.Message, new Dictionary<string, object>
                {
                     { nameof(Exception), ex}
                });
            }
        }
    }
}
