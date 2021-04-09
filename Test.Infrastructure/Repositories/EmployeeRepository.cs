using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Test.Application.Interfaces.Infrastructure;
using Test.Domain.Employees;

namespace Test.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(Employee entity)
        {
            entity.UpdatedAt = DateTime.Now;
            var sql = "Insert into Employees (FirstName,MiddleName,LastName,UpdatedAt) VALUES (@FirstName,@MiddleName,@LastName,@UpdatedAt)";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ZoobookDB")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Employees WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ZoobookDB")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Employee>> GetAllAsync()
        {
            var sql = "SELECT * FROM Employees";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ZoobookDB")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Employee>(sql);
                return result.ToList();
            }
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Employees WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ZoobookDB")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Employee>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Employee entity)
        {
            entity.UpdatedAt = DateTime.Now;
            var sql = "UPDATE Employees SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, UpdatedAt = @UpdatedAt  WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ZoobookDB")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
