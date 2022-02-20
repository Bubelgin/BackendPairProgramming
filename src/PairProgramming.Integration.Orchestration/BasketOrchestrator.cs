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

        public async Task<IntegrationGetUserBasketResponse> GetUserBasket(IntegrationGetUserBasketRequest request)
        {
            var basketData = userBasketDataProvider.GetUserBasketData(request.SessionId);
            return await Task.FromResult(new IntegrationGetUserBasketResponse()
            {
                BasketItems = basketData
            });
        }

        public Task<IntegrationAddToUserBasketResponse> AddToUserBasket(IntegrationAddToUserBasketRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
