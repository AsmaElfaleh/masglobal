using MasGlobal.Employees.Models;
using MasGlobal.Employees.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobal.Employees.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMasGlobalEmployeeService _masGlobalEmployeeService;

        public EmployeesController(IMasGlobalEmployeeService masGlobalEmployeeService)
        {
            _masGlobalEmployeeService = masGlobalEmployeeService;
        }
        /// <summary>
        /// Gets a list of employees with their data.
        /// </summary>
        /// <response code="200">Returns the list of employees</response>
        [HttpGet]
        [SwaggerOperation("GetEmployees")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Employee>), description: "Returns the list of employees")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _masGlobalEmployeeService.GetEmployees();
            return new ObjectResult(employees);
        }

        /// <summary>
        /// Gets an employee by Id with their data.
        /// </summary>
        /// <response code="200">Returns an employee</response>
        [HttpGet("{id}")]
        [SwaggerOperation("GetEmployeeById")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Employee>), description: "Returns the list of employees")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            var employee = await _masGlobalEmployeeService.GetEmployeeById(id);
            return new ObjectResult(employee);
        }
    }
}
