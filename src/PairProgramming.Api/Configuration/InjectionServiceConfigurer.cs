using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PairProgramming.Api.Processors;
using PairProgramming.Api.Services;
using PairProgramming.Common.Integration;
using PairProgramming.Common.Integration.ApiFacade;
using PairProgramming.Common.Services;
using PairProgramming.Orchestration;
using PairProgramming.Orchestration.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;

namespace PairProgramming.Api.Configuration
{
    public static class InjectionServiceConfigurer
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            ConfigureGenericApiServices(services);
            ConfigureGenericApiServices(services);
            ConfigureAuthentication(services);
            ConfigureHttpClientBuilders(services);
            ConfigureGenericCommonServices(services);
            ConfigureBasket(services);
        }

        public static MapperConfiguration CreateMapperConfiguration()
        {
            var allAssemblies = GetAllAssemblies();

            var profileTypes = allAssemblies
                .Select(a => a.GetTypes()
                    .Where(t => typeof(Profile).IsAssignableFrom(t)))
                .Aggregate((firstList, secondList) => firstList.Union(secondList));

            var profiles = profileTypes
                .Select(p => Activator.CreateInstance(p))
                .Cast<Profile>();

            return new AutoMapper.MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });
        }

        private static void ConfigureAuthentication(IServiceCollection services)
        { 
            services.AddScoped<ICurrentUser, CurrentUser>();
        }

        private static void ConfigureBasket(IServiceCollection services)
        {
            services.AddScoped<IOrchestrator<OrchestrationGetBasketRequest, OrchestrationGetBasketResponse>, BasketOrchestrator>();
        }

        private static void ConfigureGenericApiServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(IControllerLogic<,,,>), typeof(ControllerLogic<,,,>));
            services.AddScoped(typeof(IApiProcessor<>), typeof(DefaultApiProcessor<>));
        }

        private static void ConfigureHttpClientBuilders(IServiceCollection services)
        {
            services.AddHttpClient("default")
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
                {
                    UseCookies = false
                });
            services.AddHttpClient<IIntegrationService, IntegrationService>()
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip
                })
                .ConfigureHttpClient(
                    (sp, httpClient) =>
                    {
                        var httpClientOptions = sp
                            .GetRequiredService<IOptions<IntegrationServiceOptions>>()
                            .Value;
                        httpClient.BaseAddress = new Uri(httpClientOptions.BaseUrl);
                        httpClient.Timeout = TimeSpan.FromSeconds(httpClientOptions.ApiToIntegrationTimeoutInSeconds);
                    })
                .SetHandlerLifetime(TimeSpan.FromMinutes(4));
        }

        private static IMapper CreateAndConfigureMapper()
        {
            return CreateMapperConfiguration().CreateMapper();
        }

        private static IEnumerable<Assembly> GetAllAssemblies()
        {
            var apiAssembly = typeof(InjectionServiceConfigurer).GetTypeInfo().Assembly;
            var otherFirstGroupAssemblies = apiAssembly
                .GetReferencedAssemblies()
                .Where(an => an.Name.StartsWith("PairProgramming"))
                .Select(an => Assembly.Load(an));

            var allAssemblies = new List<Assembly> { apiAssembly };
            allAssemblies.AddRange(otherFirstGroupAssemblies);

            return allAssemblies;
        }
        private static void ConfigureGenericCommonServices(IServiceCollection services)
        {
            services.AddScoped<IClientContext, ClientContext>();
            services.AddSingleton<IMapper>(CreateAndConfigureMapper());
        }
    }
}
