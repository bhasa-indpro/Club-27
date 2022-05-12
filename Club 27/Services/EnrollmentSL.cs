using Club_27.Models;
using Microsoft.EntityFrameworkCore;

namespace Club_27.Services
{
    public class EnrollmentSL
    {
        private readonly Club27DBContext _context;

        public EnrollmentSL(Club27DBContext context)
        {
            _context = context;
        }



        public string CreateEnrollment(Enrollment employeeActivity)
        {
            var count = _context.Enrollments.Where(x => x.EmployeeID == employeeActivity.EmployeeID).Count();
            if (count < 4)
            {
                try
                {
                    _context.Enrollments.Add(employeeActivity);
                    _context.SaveChanges();
                    return "Success";

                }
                catch (DbUpdateException)
                {
                    return "Error - Duplicate Enrollment";
                }
            }
            else
                return "Error - Maximum of 4 activities only";

        }

        public bool DeleteEnrollment(Enrollment employeeActivity)
        {
            try
            {
                var enr = _context.Enrollments.Where(x => x.EnrollmentID == employeeActivity.EnrollmentID).FirstOrDefault();
                if (enr != null)
                {
                    _context.Enrollments.Remove(enr);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string UpdateEnrollment(int id, Enrollment employeeActivity)
        {
            try
            {
                //var enr = _context.Enrollments.Where(x => x.EnrollmentID == employeeActivity.EnrollmentID)
                //            .Include(x => x.Employee).Include(x => x.Activity).Include(x => x.Team).FirstOrDefault();
                //var count = _context.Enrollments.Where(x => x.EmployeeID == employeeActivity.EmployeeID).Count();
                var enr = GetEnrollment(id);

                enr.EmployeeID = employeeActivity.EmployeeID;
                enr.ActivityID = employeeActivity.ActivityID;                
                enr.TeamID = employeeActivity.TeamID;

                _context.SaveChanges();
                return "Success";
            }
            catch (DbUpdateException)
            {
                return "Error - Duplicate Enrollment";
            }
        }

        public Enrollment GetEnrollment(int id)
        {
            try
            {
                var enr = _context.Enrollments.Where(x => x.EnrollmentID == id).FirstOrDefault();
                if (enr != null)
                {
                    return enr;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IList<Enrollment> AllEnrollment()
        {
            try
            {
                List<Enrollment> enr = _context.Enrollments.Include(x => x.Employee).Include(x => x.Activity).Include(x => x.Team).ToList();
                if (enr != null)
                {
                    return enr;
                }
                else
                {

                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
