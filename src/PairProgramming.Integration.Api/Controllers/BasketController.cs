using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PairProgramming.Common.Integration.ApiFacade;
using PairProgramming.Common.Integration.Dto;
using PairProgramming.Common.Integration.Dto.ApiToIntegration.Basket;
using PairProgramming.Integration.Orchestration.Interfaces;

namespace PairProgramming.Integration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase, IIntegrationBasket
    {
        private readonly IBasketOrchestrator basketOrchestrator;

        public BasketController(IBasketOrchestrator basketOrchestrator)
        {
            this.basketOrchestrator = basketOrchestrator;
        }

        [HttpGet]
        public async Task<GetUserBasketResponseDto> GetUserBasket([FromQuery] IntegrationGetUserBasketRequest request)
        {
            return await basketOrchestrator.GetUserBasket(request);
        }

        [HttpPost]
        public async Task<IntegrationBasketResponse> AddToUserBasket(IntegrationAddToUserBasketRequest request)
        {
            return await basketOrchestrator.AddToUserBasket(request);
        }
    }
}
