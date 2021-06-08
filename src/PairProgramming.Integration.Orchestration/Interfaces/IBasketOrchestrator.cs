using System.Threading.Tasks;
using PairProgramming.Common.Integration.Dto;
using PairProgramming.Common.Integration.Dto.ApiToIntegration.Basket;

namespace PairProgramming.Integration.Orchestration.Interfaces
{
    public interface IBasketOrchestrator
    {
        Task<GetUserBasketResponseDto> GetUserBasket(IntegrationGetUserBasketRequest request);
        Task<IntegrationBasketResponse> AddToUserBasket(IntegrationAddToUserBasketRequest request);
    }
}
