using Microsoft.Extensions.DependencyInjection;
using Test.Application.Employees.Commands.CreateEmployee;
using Test.Application.Employees.Commands.DeleteEmployee;
using Test.Application.Employees.Commands.UpdateEmployee;
using Test.Application.Employees.Queries.GetAllEmployee;
using Test.Application.Employees.Queries.GetEmployee;

namespace Test.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            // EMPLOYEE use cases - commands and queries
            services.AddScoped<ICreateEmployeeCommand, CreateEmployeeCommand>();
            services.AddScoped<IUpdateEmployeeCommand, UpdateEmployeeCommand>();
            services.AddScoped<IDeleteEmployeeCommand, DeleteEmployeeCommand>();
            services.AddScoped<IGetEmployeeQuery, GetEmployeeQuery>();
            services.AddScoped<IGetAllEmployeeQuery, GetAllEmployeeQuery>();
        }
    }
}
