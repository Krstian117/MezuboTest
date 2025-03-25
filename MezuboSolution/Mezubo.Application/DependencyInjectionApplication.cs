namespace Mezubo.Application
{
    using Mezubo.Domain.Mapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Sistran.Extensions.Core.Application;

    public static class DependencyInjectionApplication
    {
        internal record Main;

        public static WebApplicationBuilder AddApplication(this WebApplicationBuilder builder)
        {
            builder.Services.AddCoreApplication<Main>();
            builder.Services.AddAutoMapper(typeof(MezuboProfile).Assembly);

            return builder;
        }
    }
}
