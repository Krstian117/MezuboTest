namespace Mezubo.Application
{
    using Microsoft.AspNetCore.Builder;
    using Sistran.Extensions.Core.Application;

    public static class DependencyInjectionApplication
    {
        internal record Main;

        public static WebApplicationBuilder AddApplication(this WebApplicationBuilder builder)
        {
            builder.Services.AddCoreApplication<Main>();
           // builder.Services.AddValidatorsFromAssemblyContaining<SearchListRiskValidator>();

            return builder;
        }
    }
}
