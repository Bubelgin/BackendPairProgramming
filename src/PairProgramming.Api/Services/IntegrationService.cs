using System;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PairProgramming.Common.Constants;
using PairProgramming.Common.Integration;
using PairProgramming.Common.Integration.ApiFacade;
using PairProgramming.Common.Integration.Dto;
using PairProgramming.Common.Integration.Dto.ApiToIntegration.Basket;
using PairProgramming.Common.Services;

namespace PairProgramming.Api.Services
{
    public class IntegrationService : IIntegrationService
    {
        private readonly HttpClient client;
        private readonly IntegrationServiceOptions configuration;
        private readonly ILogger<IntegrationService> logger;
        private readonly IServiceProvider serviceProvider;

        public IntegrationService(HttpClient httpClient,
            ILogger<IntegrationService> logger,
            IOptions<IntegrationServiceOptions> options,
            IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            configuration = options.Value;
            this.logger = logger;
            client = httpClient;
        }

        public async Task<GetUserBasketResponseDto> GetUserBasket(IntegrationGetUserBasketRequest request)
        {
            return await Execute<GetUserBasketResponseDto>(async () => await client.GetAsync(configuration.UserBasketEndpoint));
        }

        public async Task<IntegrationBasketResponse> AddToUserBasket(IntegrationAddToUserBasketRequest request)
        {
            return await Execute(async () => await client.PostAsync(configuration.UserBasketEndpoint, ToStringContent(request)), async response => await response.Content.ReadAsAsync<IntegrationBasketResponse>());
        }

        private async Task<T> Execute<T>(Func<Task<HttpResponseMessage>> op, Func<HttpResponseMessage, Task<T>> errorHandler = null, [CallerMemberName] string callerName = "") where T : class
        {
            try
            {
                AddCustomHeaders(this.client, this.serviceProvider);
                var response = await op();
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }

                LogBadRequest(response);

                if (errorHandler != null)
                {
                    return await errorHandler(response);
                }
            }
            catch (Exception e)
            {
                logger.LogCritical(e, $"{GetType().FullName} {callerName}");
            }

            return null;
        }

        private static void AddCustomHeaders(HttpClient httpClient, IServiceProvider serviceProvider)
        {
            var currentUser = (ICurrentUser)serviceProvider.GetService(typeof(ICurrentUser));
            httpClient.DefaultRequestHeaders.Clear();

            if (currentUser?.CorrelationId != null)
            {
                httpClient.DefaultRequestHeaders.Add(HeaderConstants.CorrelationId, currentUser.CorrelationId);
            }

            if (currentUser?.SessionId != null)
            {
                httpClient.DefaultRequestHeaders.Add(HeaderConstants.SessionId, currentUser.SessionId);
            }
        }
        private void LogBadRequest(HttpResponseMessage response)
        {
            logger.LogError(
                $"Failed response from Integration service. " +
                $"Request url: {response.RequestMessage.RequestUri}. " +
                $"Response status code: {response.StatusCode}. " +
                $"Reason: {response.ReasonPhrase}");
        }

        private static StringContent ToStringContent(object model)
        {
            var formatter = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            return new StringContent(JsonConvert.SerializeObject(model, formatter), Encoding.UTF8, "application/json");
        }
    }
}
