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
    public class EnrollmentsController : ControllerBase
    {
        private readonly EnrollmentSL enrollmentSL;

        public EnrollmentsController(EnrollmentSL enrollment)
        {
            enrollmentSL = enrollment;
        }

        // GET: api/Enrollments
        [HttpGet]
        public ActionResult<IList<Enrollment>> GetEnrollments()
        {
            return enrollmentSL.AllEnrollment().ToList();
        }

        // GET: api/Enrollments/5
        [HttpGet("{id}")]
        public ActionResult<Enrollment> GetEnrollment(int id)
        {
            var enrollment = enrollmentSL.GetEnrollment(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return enrollment;
        }

        // PUT: api/Enrollments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutEnrollment(int id, Enrollment employeeActivity)
        {
            if (id != employeeActivity.EnrollmentID)
            {
                return BadRequest();
            }
            else
            {
                if (enrollmentSL.UpdateEnrollment(id, employeeActivity) == "Success")
                    return Ok();
                else
                    return BadRequest();
            }
        }

        // POST: api/Enrollments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Enrollment> PostEnrollment(Enrollment employeeActivity)
        {
            var enrollment = enrollmentSL.CreateEnrollment(employeeActivity);
            if (enrollment == "Success")
                return Ok(enrollment);
            else
                return BadRequest();
        }

        // DELETE: api/Enrollments/5
        [HttpDelete("{id}")]
        public ActionResult DeleteEnrollment(int id)
        {
            var enrollment = enrollmentSL.GetEnrollment(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            else
            {
                enrollmentSL.DeleteEnrollment(enrollment);
                return Ok();
            }
        }

        //private bool EnrollmentExists(int id)
        //{
        //    return _context.Enrollments.Any(e => e.EnrollmentID == id);
        //}
    }
}
