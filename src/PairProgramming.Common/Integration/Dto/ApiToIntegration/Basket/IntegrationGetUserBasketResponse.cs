using System.Collections.Generic;

namespace PairProgramming.Common.Integration.Dto.ApiToIntegration.Basket
{
    public class IntegrationGetUserBasketResponse : IntegrationResponseBaseDto
    {
        public List<string> BasketItems { get; set; }
    }
}
