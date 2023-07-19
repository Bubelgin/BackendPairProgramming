using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PairProgramming.Common.Integration.Dto.ApiToIntegration;
using PairProgramming.Integration.Api.Configuration;
using PairProgramming.Integration.Api.Filters;
using PairProgramming.Integration.Api.Models.Automapper;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Program), typeof(Maps));
builder.Services.ConfigureAppOptions(builder.Configuration);
builder.Services.ConfigureDependencyInjection(builder.Configuration);
builder.Services.AddControllers(options =>
{
    options.Filters.Add<IntegrationRequestFilter<IntegrationRequestBase>>();
});

builder.Host.ConfigureDefaults(args);
builder.Host.UseContentRoot(Directory.GetCurrentDirectory());
var app = builder.Build();
if (app.Environment.IsDevelopment())
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



app.Run();

//namespace PairProgramming.Integration.Api
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            CreateHostBuilder(args).Build().Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });
//    }
//}
