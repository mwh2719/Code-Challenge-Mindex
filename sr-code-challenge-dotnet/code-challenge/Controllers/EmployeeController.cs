using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using challenge.Services;
using challenge.Models;

namespace challenge.Controllers
{
    [Route("api/employee")]
    public class EmployeeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            _logger.LogDebug($"Received employee create request for '{employee.FirstName} {employee.LastName}'");

            _employeeService.Create(employee);

            return CreatedAtRoute("getEmployeeById", new { id = employee.EmployeeId }, employee);
        }

        [HttpGet("{id}", Name = "getEmployeeById")]
        [Route("{id}")]
        public IActionResult GetEmployeeById(String id)
        {
            _logger.LogDebug($"Received employee get request for '{id}'");

            var employee = _employeeService.GetById(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult ReplaceEmployee(String id, [FromBody]Employee newEmployee)
        {
            _logger.LogDebug($"Recieved employee update request for '{id}'");

            var existingEmployee = _employeeService.GetById(id);
            if (existingEmployee == null)
                return NotFound();

            _employeeService.Replace(existingEmployee, newEmployee);

            return Ok(newEmployee);
        }

        [HttpGet("reports/{id}", Name = "getEmployeeReports")]
        [Route("reports/{id}")]
        public IActionResult GetEmployeeReports(String id)
        {
            _logger.LogDebug($"Received employee reports get request for '{id}'");

            var employee = _employeeService.GetById(id);

            if (employee == null)
                return NotFound();

            ReportingStructure employeeReport = new ReportingStructure(employee);

            return Ok(employeeReport);
        }

        [HttpPost("compensation", Name = "createEmployeeCompensation")]
        [Route("compensation")]
        public IActionResult CreateEmployeeCompensation([FromBody] Compensation compensation)
        {
            _logger.LogDebug($"Received employee create compensation request for '{compensation.employee.FirstName} {compensation.employee.LastName}'");

            _employeeService.CreateCompensation(compensation);


            return CreatedAtRoute("getEmployeeCompensation", new { id = compensation.employee.EmployeeId }, compensation);
        }

        [HttpGet("compensation/{id}", Name = "getEmployeeCompensation")]
        [Route("compensation/{id}")]
        public IActionResult GetEmployeeCompensation(String id)
        {
            _logger.LogDebug($"Received employee compensation get request for '{id}'");

            var employeeCompensation = _employeeService.GetCompensationById(id);

            if (employeeCompensation == null)
                return NotFound();


            return Ok(employeeCompensation);
        }
    }
}
