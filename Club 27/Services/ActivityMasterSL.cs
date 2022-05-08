using Club_27.Models;
using Microsoft.EntityFrameworkCore;

namespace Club_27.Services
{
    public class ActivityMasterSL
    {
        private readonly Club27DBContext _context;

        public ActivityMasterSL(Club27DBContext context)
        {
            _context = context;
        }



        public bool CreateActivity(ActivityMaster activityMaster)
        {
            try
            {
                _context.ActivityMasters.Add(activityMaster);
                _context.SaveChanges();
                return true;

            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public bool DeleteActivity(ActivityMaster activityMaster)
        {
            try
            {

                var act = _context.ActivityMasters.Where(x => x.ActivityID == activityMaster.ActivityID).FirstOrDefault();
                if (act != null)
                {
                    _context.ActivityMasters.Remove(act);
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

        public bool UpdateActivity(ActivityMaster activityMaster)
        {
            try
            {
                var act = _context.ActivityMasters.Where(x => x.ActivityID == activityMaster.ActivityID).FirstOrDefault();
                if (act != null)
                {

                    act.ActivityName = activityMaster.ActivityName;

                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public ActivityMaster GetActivity(int id)
        {
            try
            {
                var act = _context.ActivityMasters.Where(x => x.ActivityID == id).FirstOrDefault();
                if (act != null)
                {
                    return act;
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

        public IList<ActivityMaster> AllActivity()
        {
            try
            {
                List<ActivityMaster> act = _context.ActivityMasters.ToList();
                if (act != null)
                {
                    return act;
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
