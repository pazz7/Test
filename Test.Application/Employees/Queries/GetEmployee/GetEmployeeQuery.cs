using AutoMapper;
using Serilog;
using System;
using System.Threading.Tasks;
using Test.Application.Employees.Models;
using Test.Application.Interfaces;

namespace Test.Application.Employees.Queries.GetEmployee
{
    public class GetEmployeeQuery : IGetEmployeeQuery
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEmployeeQuery(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<EmployeeGetModel> Execute(int employeeId)
        {
            _logger.Information("Retrieving an Employee");

            try
            {
                var employee = await _unitOfWork.Employees.GetByIdAsync(employeeId);

                return _mapper.Map<EmployeeGetModel>(employee);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message, null);
                throw;
            }
        }
    }
}
