using Microsoft.AspNetCore.Builder;

namespace PairProgramming.Api.Configuration
{
    public static class MvcApplicationConfigurer
    {
        public static void ConfigureMvcApplication(this IApplicationBuilder application)
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
