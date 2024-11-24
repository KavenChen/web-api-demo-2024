using Snowflake.Core;
using WebApiDemo.Data.Interfaces;
using WebApiDemo.Entity.DAOs;
using WebApiDemo.Entity.Results;
using WebApiDemo.Service.Interfaces;

namespace WebApiDemo.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Result<long, string>> CreateEmployeeAsync(string name)
        {
            try
            {
                var idWorker = new IdWorker(1, 1);
                var employee = new Employee()
                {
                    Id = idWorker.NextId(),
                    Name = name
                };

                await _employeeRepository.CreateEmployeeAsync(employee);

                return new Result<long, string>(true, employee.Id, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result<long, string>(false, default, $"CreateEmployeeAsync Error: Message: {ex.Message}, StackTrace: {ex.StackTrace}");
            }
        }

        public async Task<Result<Employee, string>> GetEmployeeAsync(long id)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeAsync(id);

                if (employee == null)
                {
                    return new Result<Employee, string>(false, default, "GetEmployeeAsync Failed: employee not found.");
                }
                else
                {
                    return new Result<Employee, string>(true, employee, string.Empty);
                }
            }
            catch (Exception ex)
            {
                return new Result<Employee, string>(false, default, $"GetEmployeeAsync Error: Message: {ex.Message}, StackTrace: {ex.StackTrace}");
            }
        }
    }
}
