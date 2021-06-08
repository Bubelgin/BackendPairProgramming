using System.Security.Claims;

namespace PairProgramming.Common.Services
{
    public interface ICurrentUser
    {
        ClaimsPrincipal Principal { get; }
        string SessionId { get; }

        string CorrelationId { get; }
    }
}
