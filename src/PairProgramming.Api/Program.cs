using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PairProgramming.Api.Configuration;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureApiServices(builder.Environment);
builder.Services.ConfigureOptionServices();
builder.Services.ConfigureDependencyInjection();

builder.Services.AddApplicationInsightsTelemetry();

builder.Host.ConfigureDefaults(args);
builder.Host.UseContentRoot(Directory.GetCurrentDirectory());
var app = builder.Build();
app.ConfigureMvcApplication();
app.ConfigureSwaggerApplication(app.Environment);
app.Run();
