using AutoMapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Application.Employees.Models;
using Test.Application.Interfaces;

namespace Test.Application.Employees.Queries.GetAllEmployee
{
    public class GetAllEmployeeQuery : IGetAllEmployeeQuery
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllEmployeeQuery(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<EmployeeGetModel>> Execute()
        {
            _logger.Information("Retrieving All Employee");

            try
            {
                var employee = await _unitOfWork.Employees.GetAllAsync();

                var employeeModel = _mapper.Map<IReadOnlyList<EmployeeGetModel>>(employee);

                return employeeModel;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message, null);
                throw;
            }
        }
    }
}
