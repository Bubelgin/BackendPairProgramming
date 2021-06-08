using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PairProgramming.Common.Integration.Dto.ApiToIntegration;
using PairProgramming.Integration.Api.Filters;
using PairProgramming.Integration.Data;
using PairProgramming.Integration.Orchestration;
using PairProgramming.Integration.Orchestration.Interfaces;

namespace PairProgramming.Integration.Api.Configuration
{
    public static class InjectionServiceConfigurator
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging();
            services.AddMemoryCache();
            services.AddScoped<IntegrationRequestFilter<IntegrationRequestBaseDto>>();

            services.AddScoped<IBasketOrchestrator, BasketOrchestrator>();
            services.AddSingleton<IUserBasketDataProvider, UserBasketDataProvider>();
        }
    }
}
