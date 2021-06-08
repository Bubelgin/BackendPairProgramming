namespace PairProgramming.Api.Processors
{
    public interface IApiProcessor<TOrchestratorResult>
    {
        void Process(TOrchestratorResult item);
    }
}
