using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PairProgramming.Common.Integration;

namespace PairProgramming.Api.Configuration
{
    public static class OptionsServiceConfigurer
    {
        public static void ConfigureOptionServices(this IServiceCollection services)
        {
            var config = GenerateConfiguration();
            services.Configure<IntegrationServiceOptions>(config.GetSection(IntegrationServiceOptions.SectionKey));
            services.AddOptions();
        }

        private static IConfigurationRoot GenerateConfiguration()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("./api-settings.json");
            var config = builder.Build();
            return config;
        }
    }
}
