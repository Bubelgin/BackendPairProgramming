using PairProgramming.Common.Helpers;

namespace PairProgramming.Common.Integration.Dto.ApiToIntegration
{
    public class IntegrationRequestBaseDto
    {
        private string correlationId;

        public string CorrelationId
        {
            get => correlationId ?? StringGenerator.GenerateCorrelationId();
            set => correlationId = value;
        }

        public string ClientId { get; set; }
        public string SessionId { get; set; }
        public string Provider { get; set; }
    }
}
