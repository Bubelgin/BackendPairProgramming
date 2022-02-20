using System.Threading.Tasks;
using PairProgramming.Common.Integration.Dto;
using PairProgramming.Common.Integration.Dto.ApiToIntegration.Basket;

namespace PairProgramming.Common.Integration.ApiFacade
{
    public interface IIntegrationBasket
    {
        Task<IntegrationGetUserBasketResponse> GetUserBasket(IntegrationGetUserBasketRequest request);
        Task<IntegrationAddToUserBasketResponse> AddToUserBasket(IntegrationAddToUserBasketRequest request);
    }
}
