using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PairProgramming.Api.Configuration
{
    public interface IServiceConfigurer
    {
        void ConfigureServices(IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration);
    }
}
