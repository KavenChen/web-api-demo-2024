using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Entity.DAOs;
using WebApiDemo.Entity.Results;

namespace WebApiDemo.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<Result<long, string>> CreateEmployeeAsync(string name);
        Task<Result<Employee, string>> GetEmployeeAsync(long id);
    }
}
