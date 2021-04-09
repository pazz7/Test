using System.Threading.Tasks;
using Test.Application.Employees.Models;

namespace Test.Application.Employees.Commands.UpdateEmployee
{
    public interface IUpdateEmployeeCommand
    {
        Task<int> Execute(EmployeeUpdateModel employeeModel);
    }
}
