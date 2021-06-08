using System.Collections.Generic;

namespace PairProgramming.Api.Models
{
    public class ApiGetBasketResponse : IApiResponseWithLinks
    {
        public List<string> Items { get; set; }
        public string Links { get; set; }
    }
}
