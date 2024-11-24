using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Entity.ApiResponses;
using WebApiDemo.Service.Interfaces;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpPost(Name = "")]
        public async Task<ApiDataResponse<string>> PostAsync(string name)
        {
            var createEmployeeResult = await _employeeService.CreateEmployeeAsync(name);
            if (createEmployeeResult.IsSuccess)
            {
                return new ApiDataResponse<string>()
                {
                    Data = createEmployeeResult.Data.ToString()
                };
            }
            else
            {
                return new ApiDataResponse<string>()
                {
                    Code = 500,
                    Message = createEmployeeResult.Error
                };
            }
        }
    }
}
