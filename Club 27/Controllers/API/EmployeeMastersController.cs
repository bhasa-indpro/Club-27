using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Club_27.Models;
using Club_27.Services;

namespace Club_27.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMastersController : ControllerBase
    {
        private readonly EmployeeMasterSL employeeMasterSL;

        public EmployeeMastersController(EmployeeMasterSL emp)
        {
            employeeMasterSL = emp;
        }

        // GET: api/EmployeeMastersWAPI
        [HttpGet]
        public ActionResult<IList<EmployeeMaster>> GetEmployeeMasters()
        {

            return employeeMasterSL.AllEmployee().ToList();
        }

        // GET: api/EmployeeMastersWAPI/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeMaster> GetEmployeeMaster(int id)
        {
            var emp = employeeMasterSL.GetEmployee(id);

            if (emp == null)
            {
                return NotFound();
            }
            else
                return emp;
        }

        // PUT: api/EmployeeMastersWAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutEmployeeMaster(int id, EmployeeMaster employee)
        {
            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }
            employeeMasterSL.UpdateEmployee(employee);

            return Ok();
        }

        // POST: api/EmployeeMastersWAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<EmployeeMaster> PostEmployeeMaster(EmployeeMaster employee)
        {
            var emp = employeeMasterSL.CreateEmployee(employee);

            return Ok(employee);
        }

        // DELETE: api/EmployeeMastersWAPI/5
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployeeMaster(int id)
        {
            var emp = employeeMasterSL.GetEmployee(id);
            if (emp == null)
            {
                return NotFound();
            }
            employeeMasterSL.DeleteEmployee(emp);

            return Ok();
        }

        //private bool EmployeeMasterExists(int id)
        //{
        //    return _context.EmployeeMasters.Any(e => e.EmployeeID == id);
        //}
    }
}
