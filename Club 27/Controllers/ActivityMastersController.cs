#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Club_27.Models;
using Club_27.Services;

namespace Club_27.Controllers
{
    public class ActivityMastersController : Controller
    {
        private readonly Club27DBContext _context;
        private readonly ActivityMasterSL _activityMasterSL;

        public ActivityMastersController(Club27DBContext context, ActivityMasterSL activityMasterSL)
        {
            _context = context;
            _activityMasterSL = activityMasterSL;
        }

        // GET: ActivityMasters
        public async Task<ActionResult<IList<ActivityMaster>>> Index()
        {
            return View(_activityMasterSL.AllActivity().ToList());
        }

        // GET: ActivityMasters/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var act = _activityMasterSL.GetActivity(id);

            if (act == null)
            {
                return NotFound();
            }

            return View(act);
        }

        // GET: ActivityMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActivityMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ActivityMaster activityMaster)
        {
            var result = _activityMasterSL.CreateActivity(activityMaster);
            if (result == true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Error = "Error - Activity already exists";
            }
            return View(activityMaster);
        }

        // GET: ActivityMasters/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var activityMaster = _activityMasterSL.GetActivity(id);
            return View(activityMaster);
        }

        // POST: ActivityMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ActivityMaster activityMaster)
        {
            var result = _activityMasterSL.UpdateActivity(activityMaster);
            if (result == true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Error = "Error - Activity already exists";
            }
            return View(activityMaster);
        }

        // GET: ActivityMasters/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var activityMaster = _activityMasterSL.GetActivity(id);
            return View(activityMaster);
        }

        // POST: ActivityMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = _activityMasterSL.DeleteActivity(_activityMasterSL.GetActivity(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
