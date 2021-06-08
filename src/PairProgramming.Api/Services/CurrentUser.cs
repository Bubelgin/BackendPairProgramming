using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using PairProgramming.Common.Constants;
using PairProgramming.Common.Services;

namespace PairProgramming.Api.Services
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor context;

        public CurrentUser(IHttpContextAccessor context)
        {
            this.context = context;
        }

        public ClaimsPrincipal Principal => context.HttpContext?.User;

        public string SessionId => context.HttpContext?.Request?.Headers[HeaderConstants.SessionId].SingleOrDefault();

        public string CorrelationId => context.HttpContext?.Request?.Headers[HeaderConstants.CorrelationId].SingleOrDefault();
    }
}
