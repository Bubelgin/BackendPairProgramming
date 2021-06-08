using System;

namespace PairProgramming.Common.Helpers
{
    public static class StringGenerator
    {
        public static string GenerateCorrelationId(string session = null)
        {
            if (string.IsNullOrEmpty(session))
            {
                session = Guid.Empty.ToString();
            }

            return $"X{Guid.NewGuid().ToString("D").Substring(1)}@{session}";
        }
    }
}
