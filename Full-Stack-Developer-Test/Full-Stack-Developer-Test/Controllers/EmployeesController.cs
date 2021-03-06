using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Full_Stack_Developer_Test.Data;
using Full_Stack_Developer_Test.Entity;
using Full_Stack_Developer_Test.Services;
using Full_Stack_Developer_Test.DTO;

namespace Full_Stack_Developer_Test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService<Employee> _employeeService;

        public EmployeesController(EmployeeService<Employee> employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetEmployees()
        {
            return await _employeeService.GetNameAndRoleAsync();
        }

   
        // GET: Employees/5
        [HttpGet("{id}/employee")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetOne(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }


        // POST: Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
           
            await _employeeService.Update(employee);

            return Ok(CreatedAtAction("GetEmployee", new { id = employee.Id }, employee));
        }

        // DELETE: Employees/5
        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeService.GetOne(id);
            if (employee == null)
            {
                return NotFound();
            }

            await _employeeService.Remove(id);

            return NoContent();
        }
    }
}
