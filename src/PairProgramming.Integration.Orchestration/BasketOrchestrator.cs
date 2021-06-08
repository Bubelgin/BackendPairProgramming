using System.Threading.Tasks;
using PairProgramming.Common.Integration.Dto;
using PairProgramming.Common.Integration.Dto.ApiToIntegration.Basket;
using PairProgramming.Integration.Data;
using PairProgramming.Integration.Orchestration.Interfaces;

namespace PairProgramming.Integration.Orchestration
{
    public class BasketOrchestrator : IBasketOrchestrator
    {
        private readonly IUserBasketDataProvider userBasketDataProvider;

        public BasketOrchestrator(IUserBasketDataProvider userBasketDataProvider)
        {
            this.userBasketDataProvider = userBasketDataProvider;
        }

        public async Task<GetUserBasketResponseDto> GetUserBasket(IntegrationGetUserBasketRequest request)
        {
            var basketData = userBasketDataProvider.GetUserBasketData(request.SessionId);
            return await Task.FromResult(new GetUserBasketResponseDto()
            {
                BasketItems = basketData
            });
        }

        public Task<IntegrationBasketResponse> AddToUserBasket(IntegrationAddToUserBasketRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
