using Microsoft.AspNetCore.Builder;

namespace PairProgramming.Api.Configuration
{
    public interface IApplicationConfigurer
    {
        void ConfigureApplication(IApplicationBuilder application);
    }
}
