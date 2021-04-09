using AutoMapper;
using Serilog;
using System;
using System.Threading.Tasks;
using Test.Application.Employees.Models;
using Test.Application.Interfaces;
using Test.Domain.Employees;

namespace Test.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : ICreateEmployeeCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CreateEmployeeCommand(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Execute(EmployeeCreateModel employeeModel)
        {
            _logger.Information("Creating Employee");

            try
            {
                var employee = _mapper.Map<Employee>(employeeModel);

                return await _unitOfWork.Employees.AddAsync(employee);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message, null);
                throw;
            }
        }
    }
}
