using System.Threading.Tasks;
using Test.Application.Employees.Models;

namespace Test.Application.Employees.Commands.CreateEmployee
{
    public interface ICreateEmployeeCommand
    {
        Task<int> Execute(EmployeeCreateModel employeeModel);
    }
}
