using System.Collections.Generic;

namespace PairProgramming.Orchestration.Dtos
{
    public class OrchestrationBasketResponseBase
    {
        public bool Success { get; set; }

        public List<string> ErrorMessages { get; set; }
    }
}
