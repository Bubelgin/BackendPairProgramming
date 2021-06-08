using System.Collections.Generic;

namespace PairProgramming.Orchestration.Dtos
{
    public class OrchestrationGetBasketResponse : OrchestrationBasketResponseBase
    {
        public List<string> Items { get; set; }
    }
}
