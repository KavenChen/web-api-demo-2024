namespace WebApiDemo.Entity.ApiResponses
{
    public class ApiDataResponse<T> : ApiResponse
    {
        public T Data { get; set; }
    }
}
