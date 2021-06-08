using PairProgramming.Api.Processors;

namespace PairProgramming.Api.Services
{
    public class DefaultApiProcessor<T> : IApiProcessor<T>
    {
        public void Process(T item)
        {
        }
    }
}
