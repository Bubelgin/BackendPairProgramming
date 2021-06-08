using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using PairProgramming.Common.Constants;
using PairProgramming.Common.Services;

namespace PairProgramming.Api.Filters
{
    public class CustomSessionActionFilter : IAsyncActionFilter
    {
        private readonly IClientContext clientContext;

        public CustomSessionActionFilter(IClientContext clientContext)
        {
            this.clientContext = clientContext;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var sessionId = context.HttpContext.Request.Headers.ContainsKey(HeaderConstants.SessionId)
                ? context.HttpContext.Request.Headers[HeaderConstants.SessionId].SingleOrDefault()
                : string.Empty;
            var currentSessionId = string.IsNullOrWhiteSpace(sessionId) ? Guid.NewGuid().ToString("D") : sessionId;
            context.HttpContext.Request.Headers[HeaderConstants.SessionId] = currentSessionId;
            var resultContext = await next();
            resultContext.HttpContext.Response.Headers[HeaderConstants.SessionId] = currentSessionId;
        }
    }
}
