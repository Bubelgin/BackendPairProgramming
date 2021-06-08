namespace PairProgramming.Common.Integration
{
    public class IntegrationServiceOptions : IBaseEndpoint, IHasAttribution
    {
        public const string SectionKey = "integration";
        public string BaseUrl { get; set; }
        public string BaseEndpoint => BaseUrl;
        public string Attribution => "PP";
        public string UserBasketEndpoint { get; set; }
        public int ApiToIntegrationTimeoutInSeconds { get; set; }
    }
}
