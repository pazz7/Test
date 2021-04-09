using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Interfaces;
using Test.Application.Interfaces.Infrastructure;

namespace Test.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IEmployeeRepository employeeRepository)
        {
            Employees = employeeRepository;
        }

        public IEmployeeRepository Employees { get; }
    }
}
