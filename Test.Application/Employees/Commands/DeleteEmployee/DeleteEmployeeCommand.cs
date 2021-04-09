using Serilog;
using System;
using System.Threading.Tasks;
using Test.Application.Interfaces;

namespace Test.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IDeleteEmployeeCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public DeleteEmployeeCommand(IUnitOfWork unitOfWork, ILogger logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Execute(int id)
        {
            _logger.Information("Deleting Employee");

            try
            {
                return await _unitOfWork.Employees.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message, null);
                throw;
            }
        }
    }
}
