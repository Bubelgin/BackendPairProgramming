using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PairProgramming.Api.Models;
using PairProgramming.Api.Services;
using PairProgramming.Orchestration.Dtos;

namespace PairProgramming.Api.Controllers
{
    using IBasketGetLogic = IControllerLogic<
        ApiGetBasketRequest,
        ApiGetBasketResponse,
        OrchestrationGetBasketRequest,
        OrchestrationGetBasketResponse>;

    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/basket")]
    public class BasketController : Controller
    {
        private readonly IBasketGetLogic basketGetLogic;

        public BasketController(IBasketGetLogic basketGetLogic)
        {
            this.basketGetLogic = basketGetLogic;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(ApiGetBasketResponse), 200)]
        public async Task<IActionResult> GetBasketAsync([FromHeader] ApiGetBasketRequest request)
        {
            return await basketGetLogic.GetResponseAsync(request);
        }
    }
}
