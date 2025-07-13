using API.EmployedFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IContext _context;
        public EmployeeController(IContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Employees);
        }

        [HttpGet("V1/Employee/{id:MyConstraint}/details")]
        public IActionResult GetByIdV1(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id.Equals(id));
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        [HttpGet("V2/Employee/{id:int}/details")]
        public IActionResult GetByIdV2(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id.Equals(id));
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee cannot be null");
            }

            int maxId = _context.Employees.Max(e => e.Id);
            employee.Id = maxId + 1;

            _context.Employees.Add(employee);
            
            return CreatedAtAction(nameof(GetByIdV1), new { id = employee.Id }, employee);
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody] Employee employee)
        {
            if (employee == null || employee.Id != id)
            {
                return BadRequest("Invalid employee data");
            }

            var index = _context.Employees.FindIndex(e => e.Id == id);

            if (index == -1)
            {
                return NotFound();
            }

            _context.Employees[index] = employee;

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _context.Employees.Remove(_context.Employees.SingleOrDefault(e => e.Id.Equals(id)));
            return NoContent();
        }
    }
}
