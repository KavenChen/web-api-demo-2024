namespace WebApiDemo.Entity.ApiResponses
{
    public class ApiResponse
    {
        public ApiResponse() 
        {
            Code = 200;
            Message = "Success";
        }

        public int Code { get; set; }

        public string Message { get; set; }
    }
}
