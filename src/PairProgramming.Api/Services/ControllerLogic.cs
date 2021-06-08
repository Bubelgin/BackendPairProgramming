using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PairProgramming.Api.Models;
using PairProgramming.Api.Processors;
using PairProgramming.Orchestration;

namespace PairProgramming.Api.Services
{
    public class ControllerLogic<TApiRequest, TApiResponse, TOrchestratorRequest, TOrchestratorResponse>
        : IControllerLogic<TApiRequest, TApiResponse, TOrchestratorRequest, TOrchestratorResponse>
        where TApiResponse : IApiResponseWithLinks
    {
        private readonly IOrchestrator<TOrchestratorRequest, TOrchestratorResponse> orchestrator;
        private readonly IApiProcessor<TOrchestratorResponse> processor;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ControllerLogic(
            IOrchestrator<TOrchestratorRequest, TOrchestratorResponse> orchestrator,
            IApiProcessor<TOrchestratorResponse> processor,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            this.orchestrator = orchestrator;
            this.processor = processor;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> GetResponseAsync(TApiRequest input)
        {
            var request = this.mapper.Map<TOrchestratorRequest>(input);
            var orchestrationResponse = await this.orchestrator.GetAsync(request).ConfigureAwait(false);
            this.processor.Process(orchestrationResponse);

            var apiResponse = this.mapper.Map<TApiResponse>(orchestrationResponse);
            apiResponse.Links = this.httpContextAccessor.HttpContext.Request.Path.Value;

            return new OkObjectResult(apiResponse);
        }
    }
}
