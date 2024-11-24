using WebApiDemo.Data.Interfaces;
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
    }
}
