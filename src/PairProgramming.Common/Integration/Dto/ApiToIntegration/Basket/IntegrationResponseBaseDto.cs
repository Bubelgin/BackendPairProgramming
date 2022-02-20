namespace PairProgramming.Common.Integration.Dto
{
    public class IntegrationResponseBaseDto : IHttpResponse
    {
        public bool IsSuccessful()
        {
            return Status == ResponseStatus.Successful
                   || Status == ResponseStatus.PartiallySuccessful;
        }

        public string Status { get; set; } = ResponseStatus.Successful;
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public void PartiallySucceeded(string code, string message)
        {
            Status = ResponseStatus.PartiallySuccessful;
            ErrorCode = code;
            ErrorMessage = message;
        }

        public void PartiallySucceeded(string message)
        {
            Status = ResponseStatus.PartiallySuccessful;
            ErrorMessage = message;
        }

        public void Error(string code, string message)
        {
            Status = ResponseStatus.Error;
            ErrorCode = code;
            ErrorMessage = message;
        }

        public void Error(string message)
        {
            Status = ResponseStatus.Error;
            ErrorMessage = message;
        }

        public static T Error<T>(string message) where T : IntegrationResponseBaseDto, new()
        {
            return new T()
            {
                Status = ResponseStatus.Error,
                ErrorMessage = message
            };
        }

        public static T Error<T>(string code, string message) where T : IntegrationResponseBaseDto, new()
        {
            return new T()
            {
                Status = ResponseStatus.Error,
                ErrorCode = code,
                ErrorMessage = message
            };
        }

        public static class ResponseStatus
        {
            public static string Successful => "SUCCESSFUL";
            public static string PartiallySuccessful => "PART_SUCCESSFUL";
            public static string Error => "ERROR";
        }
    }
}
