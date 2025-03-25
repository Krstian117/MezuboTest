namespace Mezubo.Infraestructure
{
    using Mezubo.Domain.Persistence;
    using Mezubo.Infraestructure.Persistence;
    using Mezubo.Infraestructure.Persistence.Repositories;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Sistran.DataAccess;
    using Sistran.DataAccess.AdoNet.SqlServer;
    using Sistran.DataAccess.Provider;
    using Sistran.Extensions.Core.Infrastructure;

    public static class DependencyInjectionInfraestructure
    {
        public static IHostApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
        {
            builder.AddCoreInfrastructure();
            builder.Host.ConfigureDataAccess((context, opt) =>
            {
                opt.UseMSSqlServer<AdoNet, DataProcessingMezubo>(context);
            });
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IRouletteRepository, RouletteRepository>();
            builder.Services.AddScoped<IBetRepository, BetRepository>();
            return builder;
        }
    }
}
