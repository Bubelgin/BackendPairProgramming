using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using PairProgramming.Api.Results;
using PairProgramming.Common.Constants;
using PairProgramming.Common.Models;
using PairProgramming.Common.Services;

namespace PairProgramming.Api.Filters
{
    public class AppKeyFilterAttribute : IAuthorizationFilter
    {
        private const string _appKey = "4CBF9121-72C3-4CB4-893E-6DE276B22810";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var headerExists = context.HttpContext.Request.Headers.TryGetValue(HeaderConstants.ApplicationKey, out var appKeyStringValues);

            if (!headerExists || appKeyStringValues.Count > 1)
            {
                context.Result = new ForbiddenResult();
                return;
            }

            var appKey = appKeyStringValues[0];

            if (appKey != _appKey)
            {
                context.Result = new ForbiddenResult();
            }

            var clientContext = context.HttpContext.RequestServices.GetService<IClientContext>();
            clientContext.Details = new ClientDetails("a", "1");
        }
    }
}
