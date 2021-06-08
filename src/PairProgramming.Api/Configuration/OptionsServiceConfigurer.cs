using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PairProgramming.Common.Integration;

namespace PairProgramming.Api.Configuration
{
    public class OptionsServiceConfigurer : IServiceConfigurer
    {
        public void ConfigureServices(IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
        {
            var config = GenerateConfiguration(environment, configuration);
            services.Configure<IntegrationServiceOptions>(config.GetSection(IntegrationServiceOptions.SectionKey));
            services.AddOptions();
        }

        private static IConfigurationRoot GenerateConfiguration(IWebHostEnvironment environment,  IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("./api-settings.json");
            var config = builder.Build();
            return config;
        }
    }
}
