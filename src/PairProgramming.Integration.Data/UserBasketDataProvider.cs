using System;
using System.Collections.Generic;
using System.Linq;

namespace PairProgramming.Integration.Data
{
    public class UserBasketDataProvider : IUserBasketDataProvider
    {
        // In memory data
        private static Dictionary<string, List<string>> UserBasketsDataStore { get; set; } =
            new Dictionary<string, List<string>>(new Dictionary<string, List<string>>
            {
                {"User1Session", new List<string>() {"Item number 1", "Item number 2"}},
                {"User2Session", new List<string>() {"Item number 3", "Item number 4"}},
                {"User3Session", new List<string>() {"Item number 5"}},
                {"User4Session", new List<string>() {"Item number 7"}}
            });

        public List<string> GetUserBasketData(string sessionId)
        {
            return UserBasketsDataStore.SingleOrDefault(x => x.Key.Equals(sessionId, StringComparison.CurrentCultureIgnoreCase)).Value;
        }
    }
}
