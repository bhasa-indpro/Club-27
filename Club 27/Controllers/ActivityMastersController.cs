#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Club_27.Models;

namespace Club_27.Controllers
{
    public class ActivityMastersController : Controller
    {
        private readonly Club27DBContext _context;

        public ActivityMastersController(Club27DBContext context)
        {
            _context = context;
        }

        // GET: ActivityMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivityMasters.ToListAsync());
        }

        // GET: ActivityMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityMaster = await _context.ActivityMasters
                .FirstOrDefaultAsync(m => m.ActivityID == id);
            if (activityMaster == null)
            {
                return NotFound();
            }

            return View(activityMaster);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ActivityMaster activityMaster)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(activityMaster);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex is DbUpdateException)
                    {
                        //return Content("Error - Duplicate Enrollment");
                        //_logger.LogInformation(ex.ToString());
                        ViewBag.Error = "Error - Activity already exists";
                    }
                }
            }
            return View(activityMaster);
        }

        // GET: ActivityMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityMaster = await _context.ActivityMasters.FindAsync(id);
            if (activityMaster == null)
            {
                return NotFound();
            }
            return View(activityMaster);
        }

        // POST: ActivityMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActivityID,ActivityName")] ActivityMaster activityMaster)
        {
            if (id != activityMaster.ActivityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityMasterExists(activityMaster.ActivityID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(activityMaster);
        }

        // GET: ActivityMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityMaster = await _context.ActivityMasters
                .FirstOrDefaultAsync(m => m.ActivityID == id);
            if (activityMaster == null)
            {
                return NotFound();
            }

            return View(activityMaster);
        }

        // POST: ActivityMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityMaster = await _context.ActivityMasters.FindAsync(id);
            _context.ActivityMasters.Remove(activityMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityMasterExists(int id)
        {
            return _context.ActivityMasters.Any(e => e.ActivityID == id);
        }
    }
}
