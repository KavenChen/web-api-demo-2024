using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Entity.DAOs;

namespace WebApiDemo.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        Task CreateEmployeeAsync(Employee employee);
        Task<int> DeleteEmployeeAsync(long id);
        Task<Employee> GetEmployeeAsync(long id);
        Task<int> UpdateEmployeeAsync(long id, string name);
    }
}
