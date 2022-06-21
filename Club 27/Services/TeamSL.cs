using Club_27.Models;
using Microsoft.EntityFrameworkCore;

namespace Club_27.Services
{
    public class TeamSL
    {
        private readonly Club27DBContext _context;

        public TeamSL(Club27DBContext context)
        {
            _context = context;
        }



        public string CreateTeam(Team team)
        {
            try
            {
                _context.Teams.Add(team);
                _context.SaveChanges();
                return "Success";

            }
            catch (DbUpdateException)
            {
                return "Error - Team already exists for this activity";
            }
        }

        public bool DeleteTeam(Team team)
        {
            var obj = _context.Teams.Where(x => x.ID == team.ID).FirstOrDefault();
            if (obj != null)
            {
                _context.Teams.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public string UpdateTeam(int id, Team team)
        {
            try
            {
                //var enr = _context.Enrollments.Where(x => x.EnrollmentID == employeeActivity.EnrollmentID)
                //            .Include(x => x.Employee).Include(x => x.Activity).Include(x => x.Team).FirstOrDefault();
                //var count = _context.Enrollments.Where(x => x.EmployeeID == employeeActivity.EmployeeID).Count();
                var obj = GetTeam(id);

                obj.Name = team.Name;
                obj.ActivityID = team.ActivityID;
                obj.MaxLimit = team.MaxLimit;

                _context.SaveChanges();
                return "Success";
            }
            catch (DbUpdateException)
            {
                return "Error - Team already exists for this activity";
            }
        }

        public Team GetTeam(int id)
        {
            try
            {
                var obj = _context.Teams.Include(a=>a.Activity).Where(x => x.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    return obj;
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

        public IList<Team> AllTeam()
        {
            try
            {
                List<Team> obj = _context.Teams.Include(x => x.Activity).ToList();
                if (obj != null)
                {
                    return obj;
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

