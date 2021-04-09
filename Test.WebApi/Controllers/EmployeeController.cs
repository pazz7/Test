using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Application.Employees.Commands.CreateEmployee;
using Test.Application.Employees.Commands.DeleteEmployee;
using Test.Application.Employees.Commands.UpdateEmployee;
using Test.Application.Employees.Models;
using Test.Application.Employees.Queries.GetAllEmployee;
using Test.Application.Employees.Queries.GetEmployee;
using Test.WebApi.ActionFilters;

namespace Test.WebApi.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly ICreateEmployeeCommand _createEmployeeCommand;
        private readonly IUpdateEmployeeCommand _updateEmployeeCommand;
        private readonly IDeleteEmployeeCommand _deleteEmployeeCommand;
        private readonly IGetEmployeeQuery _getEmployeeQuery;
        private readonly IGetAllEmployeeQuery _getAllEmployeeQuery;
        private readonly ILogger _logger;

        public EmployeeController(ICreateEmployeeCommand createEmployeeCommand, IUpdateEmployeeCommand updateEmployeeCommand,
            IDeleteEmployeeCommand deleteEmployeeCommand, IGetAllEmployeeQuery getAllEmployeeQuery, IGetEmployeeQuery getEmployeeQuery,
            ILogger logger)
        {
            _createEmployeeCommand = createEmployeeCommand;
            _updateEmployeeCommand = updateEmployeeCommand;
            _deleteEmployeeCommand = deleteEmployeeCommand;
            _getAllEmployeeQuery = getAllEmployeeQuery;
            _getEmployeeQuery = getEmployeeQuery;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployeeGetModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeGetModel>> GetEmployee(int id)
        {
            try
            {
                var employeeResult = await _getEmployeeQuery.Execute(id);

                if (employeeResult != null)
                {
                    return Ok(employeeResult);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message, null);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(EmployeeGetModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<EmployeeGetModel>>> GetAllEmployee()
        {
            try
            {
                var employees = await _getAllEmployeeQuery.Execute();

                if (employees != null)
                {
                    return Ok(employees);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message, null);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(ModelValidationFilterAttribute))]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateModel employeeModel)
        {
            try
            {
                // TO DO this validation could still be moved to a filter attribute
                if (employeeModel == null)
                {
                    _logger.Error("Employee object received is null.");
                    return BadRequest("Employee object is null");
                }

                var data = await _createEmployeeCommand.Execute(employeeModel);

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message, null);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [ServiceFilter(typeof(ModelValidationFilterAttribute))]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeUpdateModel employeeModel)
        {
            try
            {
                // TO DO this validation could still be moved to a filter attribute
                if (employeeModel == null)
                {
                    _logger.Error("Employee object received is null.");
                    return BadRequest("Employee object is null");
                }

                var data = await _updateEmployeeCommand.Execute(employeeModel);

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message, null);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var employee = await _getEmployeeQuery.Execute(id);

                if (employee == null)
                {
                    _logger.Error($"Employee with id: {id}, not found.");
                    return NotFound();
                }

                await _deleteEmployeeCommand.Execute(employee.Id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message, null);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
