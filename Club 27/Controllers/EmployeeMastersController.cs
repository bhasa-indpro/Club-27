#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Club_27.Models;
using Club_27.ViewModels;

namespace Club_27.Controllers
{
    public class EmployeeMastersController : Controller
    {
        private readonly Club27DBContext _context;

        public EmployeeMastersController(Club27DBContext context)
        {
            _context = context;
        }

        // GET: EmployeeMasters
        public async Task<IActionResult> Index()
        {
            //var joinedData = _context.Enrollments.Include(x => x.Employee).Include(x => x.Activity).ToListAsync();
            //var j2 = joinedData.Select(x => new
            //{
            //    x.EmployeeID,
            //    x.Em
            //});
                        
            return View(await _context.EmployeeMasters.ToListAsync());
            //var t = new EnrollmentViewModel();
            //var enrolledActivities = await _context.EmployeeMasters.Include(x => x.Activity).Select(x => new EnrollmentViewModel { EmployeeVM = x , ActivityListVM = x }).ToListAsync();
            //return View(enrolledActivities);

            
        }

        // GET: EmployeeMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeMaster = await _context.EmployeeMasters
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employeeMaster == null)
            {
                return NotFound();
            }

            return View(employeeMaster);
        }

        // GET: EmployeeMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeMaster employeeMaster)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(employeeMaster);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex is DbUpdateException)
                    {
                        //return Content("Error - Duplicate Enrollment");
                        //_logger.LogInformation(ex.ToString());
                        ViewBag.Error = "Error - Please enter a new Email Address";
                    }
                }
            }
            return View(employeeMaster);
        }

        // GET: EmployeeMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeMaster = await _context.EmployeeMasters.FindAsync(id);
            if (employeeMaster == null)
            {
                return NotFound();
            }
            return View(employeeMaster);
        }

        // POST: EmployeeMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,EmployeeName,Email,Phone")] EmployeeMaster employeeMaster)
        {
            if (id != employeeMaster.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeMasterExists(employeeMaster.EmployeeID))
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
            return View(employeeMaster);
        }

        // GET: EmployeeMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeMaster = await _context.EmployeeMasters
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employeeMaster == null)
            {
                return NotFound();
            }

            return View(employeeMaster);
        }

        // POST: EmployeeMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeMaster = await _context.EmployeeMasters.FindAsync(id);
            _context.EmployeeMasters.Remove(employeeMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeMasterExists(int id)
        {
            return _context.EmployeeMasters.Any(e => e.EmployeeID == id);
        }
    }
}
