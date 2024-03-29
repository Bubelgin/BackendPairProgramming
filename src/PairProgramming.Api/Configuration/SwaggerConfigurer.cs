﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace PairProgramming.Api.Configuration
{
    public static class SwaggerConfigurer
    {
        public static void ConfigureSwaggerApplication(this IApplicationBuilder application, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                application.UseSwagger(c =>
                {
                    c.SerializeAsV2 = true;
                });
                application.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = string.Empty;
                    c.DocumentTitle = "Pair Programming | Future Platforms";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API documentation v1");
                    c.DocExpansion(DocExpansion.None);
                });
            }
        }
    }
}
