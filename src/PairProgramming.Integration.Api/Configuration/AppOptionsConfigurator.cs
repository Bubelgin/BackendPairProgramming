using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PairProgramming.Common.Integration;

namespace PairProgramming.Integration.Api.Configuration
{
    public static class AppOptionsConfigurator
    {
        public static void ConfigureAppOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IntegrationAppOptions>(configuration.GetSection(IntegrationAppOptions.SectionKey));
        }
    }
}
