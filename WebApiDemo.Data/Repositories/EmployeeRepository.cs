using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApiDemo.Data.Interfaces;
using WebApiDemo.Entity.DAOs;

namespace WebApiDemo.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            using (var sqlConnection = new SqlConnection(_connectString))
            {
                var query = @"insert into Employee (Id, CreatedDatetime, ModifiedDatetime, Name) 
                                values (@Id, @CreatedDatetime, @ModifiedDatetime, @Name);";
                await sqlConnection.ExecuteScalarAsync(query, new { employee.Id, employee.CreatedDatetime, employee.ModifiedDatetime, employee.Name });
            }
        }

        public async Task<Employee> GetEmployeeAsync(long id)
        {
            using (var sqlConnection = new SqlConnection(_connectString))
            {
                var query = "select * from Employee (nolock) where Id = @Id;";
                return await sqlConnection.QueryFirstOrDefaultAsync<Employee>(query, new { Id = id });
            }
        }
    }
}
