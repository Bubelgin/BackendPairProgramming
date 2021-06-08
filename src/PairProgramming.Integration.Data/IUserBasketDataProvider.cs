using System.Collections.Generic;

namespace PairProgramming.Integration.Data
{
    public interface IUserBasketDataProvider
    {
        public List<string> GetUserBasketData(string sessionId);
    }
}
