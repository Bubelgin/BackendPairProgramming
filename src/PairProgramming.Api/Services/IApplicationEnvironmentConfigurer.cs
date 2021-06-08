using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace PairProgramming.Api.Services
{
    public interface IApplicationEnvironmentConfigurer
    {
        void ConfigureApplication(IApplicationBuilder application, IWebHostEnvironment environment);
    }
}
