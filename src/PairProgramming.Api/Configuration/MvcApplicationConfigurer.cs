using Microsoft.AspNetCore.Builder;

namespace PairProgramming.Api.Configuration
{
    public class MvcApplicationConfigurer : IApplicationConfigurer
    {
        public void ConfigureApplication(IApplicationBuilder application)
        {
            application.UseHsts();
            application.UseHttpsRedirection();
            application.UseRouting();
            application.UseAuthentication();
            application.UseAuthorization();
            application.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
