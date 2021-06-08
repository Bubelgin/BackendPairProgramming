using PairProgramming.Api.Models;
using PairProgramming.Orchestration.Dtos;

namespace PairProgramming.Api.Automapper
{
    public class ApiBasketProfile : AutoMapper.Profile
    {
        public ApiBasketProfile()
        {
            this.CreateMap<ApiGetBasketRequest, OrchestrationGetBasketRequest>();
            this.CreateMap<OrchestrationGetBasketResponse, ApiGetBasketResponse>();
        }
    }
}
