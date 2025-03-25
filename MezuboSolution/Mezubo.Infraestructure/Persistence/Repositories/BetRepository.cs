namespace Mezubo.Infraestructure.Persistence.Repositories
{
    using ErrorOr;
    using Mezubo.Domain.Entities;
    using Mezubo.Domain.ModelServices.Bet;
    using Mezubo.Domain.Persistence;
    using Mezubo.Domain.Resources;
    using Sistran.DataAccess.SqlBuilder;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal class BetRepository : IBetRepository
    {
        private readonly IDbContext<DataProcessingMezubo> _dbContext;

        public BetRepository(IDbContext<DataProcessingMezubo> dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<ErrorOr<Success>> ValidateSameBet(CreateBetRequest createBetRequest)
        {
            try
            {
                using IDbContext db = this._dbContext.Open();
                int? result = null;
                IQuery query = db.From<BetEntity>()
                    .Where(x => x.ClientId == createBetRequest.ClientId && x.RouletteId == createBetRequest.RouletteId &&
                    x.BetType == createBetRequest.BetType && x.BetValue == createBetRequest.BetValue)
                    .Select(x => x.BetId);
                result = (await db.QueryAsync<int?>(query)).FirstOrDefault();
                if (result != null)
                {
                    return Result.Success;//El registro no existe
                }
                return Error.Failure(nameof(ValidateSameBet), Messages.BetExist);
            }
            catch (Exception ex)
            {
                return Error.Unexpected(nameof(ValidateSameBet), ex.Message, new Dictionary<string, object>
                {
                     { nameof(Exception), ex}
                });
            }
        }

        public async Task<ErrorOr<Success>> CreateBet(CreateBetRequest createBetRequest)
        {
            try
            {
                using IDbContext db = this._dbContext.Open();
                IQueryInsert query = db.Insert<BetEntity>(_ => new BetEntity
                {
                    ClientId = createBetRequest.ClientId,
                    RouletteId = createBetRequest.RouletteId,
                    BetType = createBetRequest.BetType,
                    BetValue = createBetRequest.BetValue,
                    Amount = Convert.ToDouble(createBetRequest.Amount)
                });
                await db.QueryAsync<BetEntity>(query);
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Error.Unexpected(nameof(CreateBet), ex.Message, new Dictionary<string, object>
                {
                     { nameof(Exception), ex}
                });
            }
        }
    }
}
