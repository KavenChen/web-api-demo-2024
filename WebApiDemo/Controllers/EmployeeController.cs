using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Entity.ApiResponses;
using WebApiDemo.Entity.DAOs;
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

        [HttpGet(Name = "")]
        public async Task<ApiDataResponse<Employee>> GetAsync(long id)
        {
            var getEmployeeResult = await _employeeService.GetEmployeeAsync(id);
            if (getEmployeeResult.IsSuccess)
            {
                return new ApiDataResponse<Employee>()
                {
                    Data = getEmployeeResult.Data
                };
            }
            else
            {
                return new ApiDataResponse<Employee>()
                {
                    Code = 500,
                    Message = getEmployeeResult.Error
                };
            }
        }

        [HttpPut(Name = "")]
        public async Task<ApiResponse> PutAsync(long id, string name)
        {
            var updateEmployeeResult = await _employeeService.UpdateEmployeeAsync(id, name);
            if (updateEmployeeResult.IsSuccess)
            {
                return new ApiResponse();
            }
            else
            {
                return new ApiResponse()
                {
                    Code = 500,
                    Message = updateEmployeeResult.Error
                };
            }
        }

        [HttpDelete(Name = "")]
        public async Task<ApiResponse> DeleteAsync(long id)
        {
            var deleteEmployeeResult = await _employeeService.DeleteEmployeeAsync(id);
            if (deleteEmployeeResult.IsSuccess)
            {
                return new ApiResponse();
            }
            else
            {
                return new ApiResponse()
                {
                    Code = 500,
                    Message = deleteEmployeeResult.Error
                };
            }
        }
    }
}
