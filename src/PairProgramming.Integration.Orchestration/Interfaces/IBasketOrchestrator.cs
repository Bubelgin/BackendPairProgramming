using System.Threading.Tasks;
using PairProgramming.Common.Integration.Dto;
using PairProgramming.Common.Integration.Dto.ApiToIntegration.Basket;

namespace PairProgramming.Integration.Orchestration.Interfaces
{
    public interface IBasketOrchestrator
    {
        Task<IntegrationGetUserBasketResponse> GetUserBasket(IntegrationGetUserBasketRequest request);
        Task<IntegrationAddToUserBasketResponse> AddToUserBasket(IntegrationAddToUserBasketRequest request);
    }
}
