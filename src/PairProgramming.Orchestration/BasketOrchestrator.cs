using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PairProgramming.Common.Integration.ApiFacade;
using PairProgramming.Common.Integration.Dto;
using PairProgramming.Common.Integration.Dto.ApiToIntegration.Basket;
using PairProgramming.Common.Services;
using PairProgramming.Orchestration.Dtos;

namespace PairProgramming.Orchestration
{
    public class BasketOrchestrator : IOrchestrator<OrchestrationGetBasketRequest, OrchestrationGetBasketResponse>
    {
        private readonly IMapper mapper;
        private readonly IIntegrationService integrationService;
        private readonly IClientContext clientContext;
        private readonly IOptions<OrchestrationOptions> options;
        private readonly ILogger<BasketOrchestrator> logger;

        public BasketOrchestrator(IMapper mapper,
            IIntegrationService integrationService,
            IClientContext clientContext,
            IOptions<OrchestrationOptions> options,
            ILogger<BasketOrchestrator> logger)
        {
            this.mapper = mapper;
            this.integrationService = integrationService;
            this.clientContext = clientContext;
            this.options = options;
            this.logger = logger;
        }

        public async Task<OrchestrationGetBasketResponse> GetAsync(OrchestrationGetBasketRequest request)
        {
            var integrationRequest = mapper.Map<IntegrationGetUserBasketRequest>(request);
            var result = await integrationService.GetUserBasket(integrationRequest) ?? new GetUserBasketResponseDto();
            return mapper.Map<OrchestrationGetBasketResponse>(result);
        }
    }
}
