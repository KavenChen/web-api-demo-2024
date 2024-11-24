namespace WebApiDemo.Entity.Results
{
    public class Result<TSuccess, TFail>
    {
        public Result(bool isSuccess, TSuccess data, TFail error)
        {
            IsSuccess = isSuccess;
            Data = data;
            Error = error;
        }

        public bool IsSuccess { get; }

        public TSuccess Data { get; }

        public TFail Error { get; }
    }
}
