namespace PairProgramming.Common
{
    public interface IHttpResponse
    {
        string ErrorMessage { get; }

        string Status { get; }

        bool IsSuccessful();
    }
}
