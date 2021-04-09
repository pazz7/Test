using AutoMapper;
using Serilog;
using System;
using System.Threading.Tasks;
using Test.Application.Employees.Models;
using Test.Application.Interfaces;
using Test.Domain.Employees;

namespace Test.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IUpdateEmployeeCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UpdateEmployeeCommand(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Execute(EmployeeUpdateModel employeeModel)
        {
            _logger.Information("Updating Employee");

            try
            {
                var employee = _mapper.Map<Employee>(employeeModel);

                return await _unitOfWork.Employees.UpdateAsync(employee);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message, null);
                throw;
            }
        }
    }
}
