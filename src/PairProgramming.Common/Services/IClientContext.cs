using PairProgramming.Common.Models;

namespace PairProgramming.Common.Services
{
    public interface IClientContext
    {
        ClientDetails Details { get; set; }
    }
}
