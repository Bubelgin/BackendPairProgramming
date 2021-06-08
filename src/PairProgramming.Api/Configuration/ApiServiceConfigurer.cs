using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PairProgramming.Common.Helpers;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PairProgramming.Api.Filters;
using PairProgramming.Api.Swagger;
using PairProgramming.Common.Constants;

namespace PairProgramming.Api.Configuration
{
    public class ApiServiceConfigurer : IServiceConfigurer
    {
        public void ConfigureServices(IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
        {
            services.Configure<IISServerOptions>(opt => { opt.AutomaticAuthentication = false; });

            // Add framework services.
            var builder = services.AddMvcCore(config =>
            {
                config.Filters.Add<AppKeyFilterAttribute>();
                config.Filters.Add<CustomSessionActionFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddApiVersioning();
            builder.AddDataAnnotations();
            builder.AddApiExplorer();

            var isoDateTimeConverter = new IsoDateTimeConverter
            {
                DateTimeFormat = DateFormat.IsoDateTime,
                DateTimeStyles = DateTimeStyles.AdjustToUniversal
            };

            builder.AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.Converters = new JsonConverter[] { isoDateTimeConverter };
            });

            services.AddControllers();
            if (environment.IsDevelopment())
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Pair Programming Api Documentation ",
                        Version = "v1",
                        Description = "Last Updated at " + AssemblyInfo.GetBuildDateTime().ToString("f")
                    });
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    c.CustomSchemaIds(x => x.FullName);
                    c.EnableAnnotations();
                    c.OperationFilter<AddRequiredHeaderParameters>();
                });
            }
        }
    }
}
