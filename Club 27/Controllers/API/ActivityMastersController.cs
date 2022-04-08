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
    public class ActivityMastersController : ControllerBase
    {
        private readonly ActivityMasterSL activityMasterSL;

        public ActivityMastersController(ActivityMasterSL activity)
        {
            activityMasterSL = activity;
        }

        // GET: api/ActivityMastersWAPI
        [HttpGet]
        public ActionResult<IList<ActivityMaster>> GetActivityMasters()
        {
            return activityMasterSL.AllActivity().ToList();
        }

        // GET: api/ActivityMastersWAPI/5
        [HttpGet("{id}")]
        public ActionResult<ActivityMaster> GetActivityMaster(int id)
        {
            var act = activityMasterSL.GetActivity(id);

            if (act == null)
            {
                return NotFound();
            }
            else
                return act;
        }

        // PUT: api/ActivityMastersWAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutActivityMaster(int id, ActivityMaster activityMaster)
        {
            if (id != activityMaster.ActivityID)
            {
                return BadRequest();
            }
            else
            {
                activityMasterSL.UpdateActivity(activityMaster);
                return Ok();
            }
        }

        // POST: api/ActivityMastersWAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ActivityMaster> PostActivityMaster(ActivityMaster activityMaster)
        {
            var act = activityMasterSL.CreateActivity(activityMaster);
            return Ok(act);
        }

        // DELETE: api/ActivityMastersWAPI/5
        [HttpDelete("{id}")]
        public ActionResult DeleteActivityMaster(int id)
        {
            var act = activityMasterSL.GetActivity(id);
            if (act == null)
            {
                return NotFound();
            }
            else
            {
                activityMasterSL.DeleteActivity(act);
                return Ok();
            }
        }

        //private bool ActivityMasterExists(int id)
        //{
        //    return _context.ActivityMasters.Any(e => e.ActivityID == id);
        //}
    }
}
