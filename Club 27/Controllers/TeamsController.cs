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


namespace Club_27.Controllers
{
    public class TeamsController : Controller
    {

        private readonly ILogger<TeamsController> _logger;
        private readonly TeamSL _teamSL;
        private readonly ActivityMasterSL _activityMasterSL;

        public TeamsController(ILogger<TeamsController> logger, TeamSL teamSL, ActivityMasterSL activityMasterSL)
        {
            _teamSL = teamSL;
            _activityMasterSL = activityMasterSL;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into HomeController");
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            return View(_teamSL.AllTeam().ToList());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var obj = _teamSL.GetTeam(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: EmployeeActivities/Create
        public IActionResult Create()
        {
            var TypeDropDown = _activityMasterSL.AllActivity().ToList();

            ViewBag.TypeDropDown = TypeDropDown;

            return View();
        }

        // POST: Teams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team team)
        {
            var result = _teamSL.CreateTeam(team);
            if (result == "Success")
                return RedirectToAction("Index");
            else if (result == "Error - Team already exists for this activity")
                ViewBag.DuplicateError = result;

            var TypeDropDown = _activityMasterSL.AllActivity().ToList();

            ViewBag.TypeDropDown = TypeDropDown;

            return View(team);
        }

        public IActionResult OverLimit()
        {
            return View();
        }

        public IActionResult Duplicate()
        {
            return View();
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var obj = _teamSL.GetTeam(id);

            var TypeDropDown = _activityMasterSL.AllActivity().ToList();

            ViewBag.TypeDropDown = TypeDropDown;
            return View(obj);
        }

        // POST: Teams/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Team team)
        {
            var TypeDropDown = _activityMasterSL.AllActivity().ToList();

            ViewBag.TypeDropDown = TypeDropDown;
            
            var result = _teamSL.UpdateTeam(id, team);
            if (result == "Success")
                return RedirectToAction("Index");
            else if (result == "Error - Team already exists for this activity")
                ViewBag.DuplicateError = result;
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var obj = _teamSL.GetTeam(id);
            return View(obj);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = _teamSL.DeleteTeam(_teamSL.GetTeam(id));
            return RedirectToAction(nameof(Index));
        }
    }
}

