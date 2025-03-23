namespace Mezubo.Infraestructure.Persistence.Repositories
{
    using ErrorOr;
    using Mezubo.Domain.Entities;
    using Mezubo.Domain.Enums;
    using Mezubo.Domain.Persistence;
    using Mezubo.Domain.Resources;
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
                    Status = EnumRoulette.CREATE.ToString()
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

        public async Task<ErrorOr<Success>> ValidateExistRoulette(int RouletteId)
        {
            try
            {
                using IDbContext db = this._dbContext.Open();
                int? result = null;
                IQuery query = db.From<RouletteEntity>()
                    .Where(x => x.Id == RouletteId)
                    .Select(x => x.Id);
                result = (await db.QueryAsync<int?>(query)).FirstOrDefault();
                if (result != null)
                {
                    return Result.Success;//la ruleta si existe
                }
                return Error.Failure(nameof(ValidateExistRoulette), string.Format(Messages.DontExistRoulette, RouletteId));
            }
            catch (Exception ex)
            {
                return Error.Unexpected(nameof(ValidateExistRoulette), ex.Message, new Dictionary<string, object>
                {
                     { nameof(Exception), ex}
                });
            }
        }

        public async Task<ErrorOr<Success>> UpdateRoulette(int RouletteId, EnumRoulette enumRoulette)
        {
            try
            {
                using IDbContext db = this._dbContext.Open();
                IQueryUpdate query = db.Update<RouletteEntity>()
                    .Set(_ => new RouletteEntity
                    {
                        Status = enumRoulette.ToString(),
                        OpenDate = DateTime.Now
                    })
                    .Where(c => c.Id == RouletteId);

                await db.QueryAsync<RouletteEntity>(query);
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Error.Unexpected(nameof(UpdateRoulette), ex.Message, new Dictionary<string, object>
                {
                     { nameof(Exception), ex}
                });
            }
        }
    }
}
