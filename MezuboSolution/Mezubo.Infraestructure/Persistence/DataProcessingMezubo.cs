namespace Mezubo.Infraestructure.Persistence
{
    using Sistran.DataAccess.Implementation;
    using Sistran.DataAccess.Interfaces;
    using Sistran.DataAccess.SqlBuilder;
    using Sistran.Extensions.Instrumentation.Behaviors;
    using System.Data;

    public class DataProcessingMezubo : DbContext, IDbContext<DataProcessingMezubo>
    {
        public DataProcessingMezubo(ILogBehavior logBehavior, ISqlAdapter sqlAdapter, IDbConnection dbConnection, string connectionName)
            : base(logBehavior, sqlAdapter, dbConnection, connectionName)
        {
        }
    }

}
