using System.Threading.Tasks;
using Test.Application.Employees.Models;

namespace Test.Application.Employees.Queries.GetEmployee
{
    public interface IGetEmployeeQuery
    {
        Task<EmployeeGetModel> Execute(int employeeId);
    }
}
