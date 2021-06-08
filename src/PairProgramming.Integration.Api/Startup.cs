using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PairProgramming.Common.Integration.Dto.ApiToIntegration;
using PairProgramming.Integration.Api.Configuration;
using PairProgramming.Integration.Api.Filters;
using PairProgramming.Integration.Api.Models.Automapper;

namespace PairProgramming.Integration.Api
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration conf)
        {
            configuration = conf;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup), typeof(Maps));
            services.ConfigureAppOptions(configuration);
            services.ConfigureDependencyInjection(configuration);
            services.AddControllers(options =>
            {
                options.Filters.Add<IntegrationRequestFilter<IntegrationRequestBaseDto>>();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
