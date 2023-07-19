using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PairProgramming.Api.Filters;
using PairProgramming.Api.Swagger;
using PairProgramming.Common.Constants;
using PairProgramming.Common.Helpers;
using System.Globalization;
using System.Linq;

namespace PairProgramming.Api.Configuration
{
    public static class ApiServiceConfigurer
    {
        public static void ConfigureApiServices(this IServiceCollection services, IWebHostEnvironment environment)
        {
            services.Configure<IISServerOptions>(opt => { opt.AutomaticAuthentication = false; });

            // Add framework services.
            var builder = services.AddMvcCore(config =>
            {
                config.Filters.Add<AppKeyFilterAttribute>();
                config.Filters.Add<CustomSessionActionFilter>();
            });

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
