using System;
using System.Collections.Generic;
using System.Linq;

namespace PairProgramming.Integration.Data
{
    public class UserBasketDataProvider : IUserBasketDataProvider
    {
        private static Dictionary<string, List<string>> UserBaskets { get; set; } = new Dictionary<string, List<string>>(new Dictionary<string, List<string>> { { "User1Session", new List<string>() { "Item number 1" } } });


        public List<string> GetUserBasketData(string sessionId)
        {
            return UserBaskets.SingleOrDefault(x => x.Key.Equals(sessionId, StringComparison.CurrentCultureIgnoreCase)).Value;
        }
    }
}
