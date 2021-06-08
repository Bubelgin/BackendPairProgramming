using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PairProgramming.Api.Models;

namespace PairProgramming.Api.Services
{
    public interface IControllerLogic<
        TApiRequest,
        TApiResponse,
        TOrchestratorRequest,
        TOrchestratorResponse>
        where TApiResponse : IApiResponseWithLinks
    {
        Task<IActionResult> GetResponseAsync(TApiRequest input);
    }
}
