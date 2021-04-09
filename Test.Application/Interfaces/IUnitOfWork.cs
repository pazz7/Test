using Test.Application.Interfaces.Infrastructure;

namespace Test.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
    }
}
