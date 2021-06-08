using System.Threading.Tasks;

namespace PairProgramming.Orchestration
{
    public interface IOrchestrator<TRequest, TResponse>
    {
        Task<TResponse> GetAsync(TRequest request);
    }
}
