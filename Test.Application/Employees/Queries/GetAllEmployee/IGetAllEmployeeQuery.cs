using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Application.Employees.Models;

namespace Test.Application.Employees.Queries.GetAllEmployee
{
    public interface IGetAllEmployeeQuery
    {
        Task<IReadOnlyList<EmployeeGetModel>> Execute();
    }
}
