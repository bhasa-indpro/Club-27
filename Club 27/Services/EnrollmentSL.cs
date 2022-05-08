using Club_27.Models;

namespace Club_27.Services
{
    public class EnrollmentSL
    {
        private readonly Club27DBContext _context;

        public EnrollmentSL(Club27DBContext context)
        {
            _context = context;
        }



        public bool CreateEnrollment(Enrollment employeeActivity)
        {
            try
            {
                _context.Enrollments.Add(employeeActivity);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
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

        public bool UpdateEnrollment(Enrollment employeeActivity)
        {
            try
            {
                var enr = _context.Enrollments.Where(x => x.EnrollmentID == employeeActivity.EnrollmentID).FirstOrDefault();
                if (enr != null)
                {
                    
                    enr.ActivityID = employeeActivity.ActivityID;
                    enr.EmployeeID = employeeActivity.EmployeeID;
                    enr.TeamID = employeeActivity.TeamID;

                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
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
                List<Enrollment> enr = _context.Enrollments.ToList();
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
