using Microsoft.Extensions.DependencyInjection;
using Test.Application.Interfaces;
using Test.Application.Interfaces.Infrastructure;
using Test.Infrastructure.Repositories;

namespace Test.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
