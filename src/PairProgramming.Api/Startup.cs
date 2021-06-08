using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PairProgramming.Api.Configuration;
using PairProgramming.Api.Services;

namespace PairProgramming.Api
{
    public class Startup
    {
        private readonly IServiceConfigurer apiConfigurer;
        private readonly IServiceConfigurer optionsConfigurer;
        private readonly IServiceConfigurer injectionConfigurer;
        private readonly IApplicationConfigurer mvcConfigurer;
        private readonly IApplicationEnvironmentConfigurer swaggerConfigurer;
        private readonly IWebHostEnvironment environment;
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
            : this(configuration, environment,
                new ApiServiceConfigurer(),
                new OptionsServiceConfigurer(),
                new InjectionServiceConfigurer(),
                new MvcApplicationConfigurer(),
                new SwaggerConfigurer())
        {
        }

        public Startup(IConfiguration configuration,
            IWebHostEnvironment environment,
            IServiceConfigurer apiConfigurer,
            IServiceConfigurer optionsConfigurer,
            IServiceConfigurer injectionConfigurer,
            IApplicationConfigurer mvcConfigurer,
            IApplicationEnvironmentConfigurer swaggerConfigurer
        )
        {
            this.apiConfigurer = apiConfigurer;
            this.optionsConfigurer = optionsConfigurer;
            this.injectionConfigurer = injectionConfigurer;
            this.mvcConfigurer = mvcConfigurer;
            this.swaggerConfigurer = swaggerConfigurer;
            this.environment = environment;
            this.Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            this.apiConfigurer.ConfigureServices(services, environment, Configuration);

            this.optionsConfigurer.ConfigureServices(services, environment, Configuration);

            this.injectionConfigurer.ConfigureServices(services, environment, Configuration);

            services.AddApplicationInsightsTelemetry();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.mvcConfigurer.ConfigureApplication(app);
            this.swaggerConfigurer.ConfigureApplication(app, env);
        }
    }
}
