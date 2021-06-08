namespace PairProgramming.Common.Models
{
    public class ClientDetails
    {
        public ClientDetails(string provider, string clientId)
        {
            this.Provider = provider;
            this.ClientId = clientId;
        }

        public string Provider { get; }
        public string Version { get; set; }
        public string ClientId { get; }
    }
}
