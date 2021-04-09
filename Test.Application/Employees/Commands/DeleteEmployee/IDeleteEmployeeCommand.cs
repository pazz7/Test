using System.Threading.Tasks;

namespace Test.Application.Employees.Commands.DeleteEmployee
{
    public interface IDeleteEmployeeCommand
    {
        Task<int> Execute(int id);
    }
}
