using AutoMapper;
using PairProgramming.Common.Integration.Dto;
using PairProgramming.Common.Integration.Dto.ApiToIntegration.Basket;
using PairProgramming.Orchestration.Dtos;

namespace PairProgramming.Orchestration.Automapper
{
    public class OrchestrationBasketProfile : Profile
    {
        public OrchestrationBasketProfile()
        {
            this.CreateMap<OrchestrationGetBasketRequest, IntegrationGetUserBasketRequest>();
            this.CreateMap<IntegrationGetUserBasketResponse, OrchestrationGetBasketResponse>();
        }
    }
}
