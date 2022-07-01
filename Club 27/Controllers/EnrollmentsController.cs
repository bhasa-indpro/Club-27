#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Club_27.Models;
using Microsoft.Extensions.Logging;
using Club_27.Services;
using Microsoft.AspNetCore.Authorization;
using Club_27.Authorization;

namespace Club_27.Controllers
{
    [Authorize]
    public class EnrollmentsController : Controller
    {
        private readonly Club27DBContext _context;

        private readonly ILogger<EnrollmentsController> _logger;
        private readonly EnrollmentSL _enrollmentSL;
        private readonly ActivityMasterSL _activityMasterSL;
        private readonly EmployeeMasterSL _employeeMasterSL;
        private readonly TeamSL _teamSL;

        public EnrollmentsController(Club27DBContext context, ILogger<EnrollmentsController> logger, EnrollmentSL enrollmentSL, EmployeeMasterSL employeeMasterSL, TeamSL teamSL, ActivityMasterSL activityMasterSL)
        {
            _context = context;
            _enrollmentSL = enrollmentSL;
            _activityMasterSL = activityMasterSL;
            _employeeMasterSL = employeeMasterSL;
            _teamSL = teamSL;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into HomeController");
        }

        // GET: EmployeeActivities
        public async Task<IActionResult> Index()
        {
            return View(_enrollmentSL.AllEnrollment().ToList());
        }

        // GET: EmployeeActivities/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int id)
        {
            var obj = _enrollmentSL.GetEnrollment(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: EmployeeActivities/Create
        //[WebAuthorize (RolesList=new[] {Roles.Admin})]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var TypeDropDown1 = _employeeMasterSL.AllEmployee().ToList();
            var TypeDropDown2 = _activityMasterSL.AllActivity().ToList();
            var TypeDropDown3 = _teamSL.AllTeam().ToList();

            ViewBag.TypeDropDown1 = TypeDropDown1;
            ViewBag.TypeDropDown2 = TypeDropDown2;
            ViewBag.TypeDropDown3 = TypeDropDown3;

            //TempData["tempData1"] = TypeDropDown1;
            //TempData["tempCheck"] = "Check Data";
            //TempData["tempData2"] = TypeDropDown2;
            return View();
        }

        // POST: EmployeeActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Enrollment employeeActivity)
        {

            var result = _enrollmentSL.CreateEnrollment(employeeActivity);
            if (result == "Success")
                return RedirectToAction("Index");
            else if (result == "Error - Duplicate Enrollment")
                ViewBag.Error = result;
            else if (result == "Error - Maximum of 4 activities only")
                ViewBag.Error = result;
            else if (result == "Error - Team already full")
                ViewBag.Error = result;

            var TypeDropDown1 = _employeeMasterSL.AllEmployee().ToList();
            var TypeDropDown2 = _activityMasterSL.AllActivity().ToList();
            var TypeDropDown3 = _teamSL.AllTeam().ToList();

            ViewBag.TypeDropDown1 = TypeDropDown1;
            ViewBag.TypeDropDown2 = TypeDropDown2;
            ViewBag.TypeDropDown3 = TypeDropDown3;

            return View(employeeActivity);
        }

        public IActionResult OverLimit()
        {
            return View();
        }

        public IActionResult Duplicate()
        {
            return View();
        }

       

        // GET: EmployeeActivities/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {

            
            var obj = _enrollmentSL.GetEnrollment(id);

            var TypeDropDown1 = _employeeMasterSL.AllEmployee().ToList();
            var TypeDropDown2 = _activityMasterSL.AllActivity().ToList();
            var TypeDropDown3 = _teamSL.AllTeam().ToList();

            ViewBag.TypeDropDown1 = TypeDropDown1;
            ViewBag.TypeDropDown2 = TypeDropDown2;
            ViewBag.TypeDropDown3 = TypeDropDown3;
            return View(obj);
        }

        // POST: EmployeeActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id , Enrollment employeeActivity)
        {
            
            var TypeDropDown1 = _employeeMasterSL.AllEmployee().ToList();
            var TypeDropDown2 = _activityMasterSL.AllActivity().ToList();
            var TypeDropDown3 = _teamSL.AllTeam().ToList();

            ViewBag.TypeDropDown1 = TypeDropDown1;
            ViewBag.TypeDropDown2 = TypeDropDown2;
            ViewBag.TypeDropDown3 = TypeDropDown3;

            
            var result = _enrollmentSL.UpdateEnrollment(id , employeeActivity);
            if (result == "Success")
                return RedirectToAction("Index");
            else if (result == "Error - Duplicate Enrollment")
                ViewBag.Error = result;
            else if (result == "Error - Team already full")
                ViewBag.Error = result;
            return View(employeeActivity);
        }

        // GET: EmployeeActivities/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            

            var obj = _enrollmentSL.GetEnrollment(id);
            return View(obj);
        }

        // POST: EmployeeActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var result = _enrollmentSL.DeleteEnrollment(_enrollmentSL.GetEnrollment(id));
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollments.Any(e => e.EnrollmentID == id);
        }

        [HttpPost]
        public async Task<JsonResult> GetTeamList(int id)
        {
            var teamList = _teamSL.AllTeam().Where(x => x.ActivityID == id).ToList();
            var teamDropDownItems = teamList.Select(x => new SelectListItem { Value = x.ID.ToString() , Text = x.Name }).ToList();
            var returnValue = Json(teamDropDownItems);
            return Json(teamDropDownItems);
        }       
    }
}
