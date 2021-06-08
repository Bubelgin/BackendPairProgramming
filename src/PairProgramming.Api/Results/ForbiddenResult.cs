using System;
using Microsoft.AspNetCore.Mvc;

namespace PairProgramming.Api.Results
{
    public class ForbiddenResult : ActionResult
    {
        private const int ForbiddenStatusCode = 403;

        public override void ExecuteResult(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "cannot be null");
            }

            var response = context.HttpContext.Response;

            response.StatusCode = ForbiddenStatusCode;
        }
    }
}
