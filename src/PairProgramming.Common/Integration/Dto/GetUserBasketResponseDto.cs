using System.Collections.Generic;

namespace PairProgramming.Common.Integration.Dto
{
    public class GetUserBasketResponseDto : IntegrationResponseBaseDto
    {
        public List<string> BasketItems { get; set; }
    }
}
