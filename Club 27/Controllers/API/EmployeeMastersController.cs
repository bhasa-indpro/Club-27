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
        //private readonly Club27DBContext _context;

        private readonly EmployeeMasterSL employeeMasterSL;
        //public EmployeeMastersWAPIController(Club27DBContext context)
        //{
        //    _context = context;
        //}

        public EmployeeMastersController(EmployeeMasterSL emp)
        {
            employeeMasterSL = emp;
        }
        
        // GET: api/EmployeeMastersWAPI
        [HttpGet]
        public ActionResult<IList<EmployeeMaster>> GetEmployeeMasters()
        {
            
            return employeeMasterSL.AllEmployee().ToList();
            //return await _context.EmployeeMasters.ToListAsync();
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

            //_context.Entry(employeeMaster).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!EmployeeMasterExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            employeeMasterSL.UpdateEmployee(employee);

            return Ok();
        }

        // POST: api/EmployeeMastersWAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<EmployeeMaster> PostEmployeeMaster(EmployeeMaster employee)
        {
            //_context.EmployeeMasters.Add(employeeMaster);
            //await _context.SaveChangesAsync();
            var emp = employeeMasterSL.CreateEmployee(employee);

            //return CreatedAtAction("GetEmployeeMaster", new { id = employeeMaster.EmployeeID }, employeeMaster);
            return Ok(employee);
        }

        // DELETE: api/EmployeeMastersWAPI/5
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployeeMaster(int id)
        {
            //var employeeMaster = await _context.EmployeeMasters.FindAsync(id);
            var emp = employeeMasterSL.GetEmployee(id);
            if (emp == null)
            {
                return NotFound();
            }

            //_context.EmployeeMasters.Remove(employeeMaster);
            //await _context.SaveChangesAsync();
            employeeMasterSL.DeleteEmployee(emp);

            return Ok();
        }

        //private bool EmployeeMasterExists(int id)
        //{
        //    return _context.EmployeeMasters.Any(e => e.EmployeeID == id);
        //}
    }
}
