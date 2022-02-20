using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PairProgramming.Common.Constants;
using PairProgramming.Common.Integration.Dto.ApiToIntegration;

namespace PairProgramming.Integration.Api.Filters
{
    public class IntegrationRequestFilter<T> : IActionFilter where T : IntegrationRequestBase
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext actionContext)
        {
            foreach (var argument in actionContext.ActionArguments.Values.Where(v => v is T))
            {
                if (argument is T model)
                {
                    //Any request to integration service requires these two headers to be present
                    if (!actionContext.HttpContext.Request.Headers.ContainsKey(HeaderConstants.SessionId)
                        || string.IsNullOrWhiteSpace(actionContext.HttpContext.Request.Headers[HeaderConstants.SessionId]))
                    {
                        actionContext.Result = new BadRequestResult();
                        return;
                    }

                    model.CorrelationId = actionContext.HttpContext.Request.Headers[HeaderConstants.CorrelationId];
                    model.SessionId = actionContext.HttpContext.Request.Headers[HeaderConstants.SessionId];

                    if (string.IsNullOrEmpty(model.SessionId))
                    {
                        model.SessionId = actionContext.HttpContext.Request.Headers[HeaderConstants.SessionId];
                    }
                }
            }
        }
    }
}
