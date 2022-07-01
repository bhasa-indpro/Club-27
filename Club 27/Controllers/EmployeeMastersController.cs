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
using Club_27.Services;

namespace Club_27.Controllers
{
    public class EmployeeMastersController : Controller
    {
        private readonly Club27DBContext _context;
        private readonly EmployeeMasterSL _employeeMasterSL;

        public EmployeeMastersController(Club27DBContext context, EmployeeMasterSL employeeMasterSL)
        {
            _context = context;
            _employeeMasterSL = employeeMasterSL;
        }

        // GET: EmployeeMasters
        public async Task<IActionResult> Index()
        {
            return View(_employeeMasterSL.AllEmployee().ToList());
        }

        // GET: EmployeeMasters/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var employeeMaster = _employeeMasterSL.GetEmployee(id);
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
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeMaster employeeMaster)
        {
            var result = _employeeMasterSL.CreateEmployee(employeeMaster);
            if (result == true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Error = "Error - Please enter a new Email Address";
            }
            return View(employeeMaster);
        }

        // GET: EmployeeMasters/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var employeeMaster = _employeeMasterSL.GetEmployee(id);
            return View(employeeMaster);
        }

        // POST: EmployeeMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeMaster employeeMaster)
        {
            
            var result = _employeeMasterSL.UpdateEmployee(employeeMaster);
            if (result == true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Error = "Error - Email already exists";
            }
            return View(employeeMaster);
        }

        // GET: EmployeeMasters/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
           
            var employeeMaster = _employeeMasterSL.GetEmployee(id);
            return View(employeeMaster);
        }

        // POST: EmployeeMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var result = _employeeMasterSL.DeleteEmployee(_employeeMasterSL.GetEmployee(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
