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
            //return View(await _context.Enrollments.Include(x => x.Employee).Include(x => x.Activity).Include(x => x.Team).ToListAsync());
            return View(_enrollmentSL.AllEnrollment().ToList());
        }

        // GET: EmployeeActivities/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var employeeActivity = await _context.Enrollments.Include(x => x.Activity).Include(x => x.Team).Include(x => x.Employee).FirstOrDefaultAsync(m => m.EnrollmentID == id);

            //if (employeeActivity == null)
            //{
            //    return NotFound();
            //}
            //var GetObj = _context.Enrollments.Include(x => x.Activity).Include(x => x.Venue).Include(x => x.Employee).FirstOrDefaultAsync(m => m.EnrollmentID == id);
            //ViewBag.GetObj = GetObj;
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

            //if (ModelState.IsValid)
            //{
            //    var count = _context.Enrollments.Where(x => x.EmployeeID == employeeActivity.EmployeeID).Count();


            //    if (count < 4)
            //    {
            //        //var count2 = _context.Enrollments.Where(x => x.EmployeeID == employeeActivity.EmployeeID
            //        //&& x.ActivityID == employeeActivity.ActivityID).Count();
            //        try
            //        {
            //            _context.Enrollments.Add(employeeActivity);
            //            _context.SaveChanges();
            //            return RedirectToAction("Index");
            //        }
            //        catch (Exception ex)
            //        {

            //            if (ex is DbUpdateException)
            //            {
            //                //return Content("Error - Duplicate Enrollment");
            //                _logger.LogInformation("Duplicate (CreatePost)");
            //                ViewBag.Duplicate1 = "Error - Duplicate Enrollment";
            //            }

            //        }
            //    }
            //    else
            //    {
            //        //return Content("Error - Maximum of 4 activities only");
            //        _logger.LogInformation("Exceeding (CreatePost)");
            //        ViewBag.Duplicate2 = "Error - Maximum of 4 activities only";
            //    }

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

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        var enrollmentList = _context.Enrollments.Where(x => x.Employee.EmployeeID == employeeActivity.EmployeeID).ToList();
            //        foreach (var item in enrollmentList)
            //        {
            //            if (item.Activity == employeeActivity.Activity)
            //            {
            //                ViewBag.ErrorMessage = "Error-Duplicate";
            //            }
            //        }



            //        int count = _context.Enrollments.Where(x => x.Employee.EmployeeID == employeeActivity.EmployeeID).Count();
            //        //IList<ActivityMaster> actlist = (IList<ActivityMaster>)_context.Enrollments.Where(x => x.Employee.EmployeeID == employeeActivity.EmployeeID).ToListAsync();

            //        if (count < 4)
            //        {
            //            _context.Add(employeeActivity);
            //            _context.SaveChanges();
            //            return RedirectToAction(nameof(Index));
            //        }
            //        else
            //        {
            //            return RedirectToAction(nameof(OverLimit));
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex is DbUpdateException)
            //    {
            //        ViewBag
            //    }
            //}
            //return View(employeeActivity);
        }

        public IActionResult OverLimit()
        {
            return View();
        }

        public IActionResult Duplicate()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(int empID, int actID, int[] actlist)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        int count = _context.Enrollments.Where(x => x.Employee.EmployeeID == empID).Count();
        //        int dupFlag = 0;
        //        foreach (var i in actlist)
        //        {
        //            if (actID == i)
        //            {
        //                dupFlag = 1;
        //                break;
        //            }                   
        //            else
        //                dupFlag = 0;
        //        }

        //        if (count < 4 && dupFlag == 0)
        //        {
        //            Enrollment employeeActivity = new Enrollment()
        //            {
        //                EmployeeID = empID, ActivityID = actID

        //            };

        //            _context.Add(employeeActivity);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    return View();
        //}

        // GET: EmployeeActivities/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var employeeActivity = await _context.Enrollments.FindAsync(id);
            //if (employeeActivity == null)
            //{
            //    return NotFound();
            //}
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
            //if (id != employeeActivity.EnrollmentID)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            var TypeDropDown1 = _employeeMasterSL.AllEmployee().ToList();
            var TypeDropDown2 = _activityMasterSL.AllActivity().ToList();
            var TypeDropDown3 = _teamSL.AllTeam().ToList();

            ViewBag.TypeDropDown1 = TypeDropDown1;
            ViewBag.TypeDropDown2 = TypeDropDown2;
            ViewBag.TypeDropDown3 = TypeDropDown3;

            //    try
            //    {
            //        employeeActivity.EnrollmentID = id;
            //        _context.Update(employeeActivity);
            //        await _context.SaveChangesAsync();
            //        return RedirectToAction(nameof(Index));
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!EnrollmentExists(employeeActivity.EnrollmentID))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        if (ex is DbUpdateException)
            //        {
            //            //return Content("Error - Duplicate Enrollment");
            //            ViewBag.Duplicate1 = "Error - Duplicate Enrollment";
            //        }
            //    }

            //}
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
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var employeeActivity = await _context.Enrollments
            //    .FirstOrDefaultAsync(m => m.EnrollmentID == id);
            //if (employeeActivity == null)
            //{
            //    return NotFound();
            //}

            //return View(employeeActivity);

            var obj = _enrollmentSL.GetEnrollment(id);
            return View(obj);
        }

        // POST: EmployeeActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var employeeActivity = await _context.Enrollments.FindAsync(id);
            //_context.Enrollments.Remove(employeeActivity);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

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

        //[HttpPost]
        //public async Task<JsonResult> GetActivityList(int id)
        //{
        //    var selectedTeam = _teamSL.GetTeam(id);
        //    var selectedTeamName = selectedTeam.Name;
        //    var teamListFromName = _teamSL.AllTeam().Where(x => x.Name == selectedTeamName).ToList();
        //    var activityListFromName = _
        //    var activityDropDownItems = teamList.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Name }).ToList();
        //    var returnValue = Json(teamDropDownItems);
        //    return Json(teamDropDownItems);
        //}

       
    }
}
