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
    public class VenuesController : Controller
    {
        private readonly ILogger<VenuesController> _logger;
        private readonly VenueSL _venueSL;
        private readonly ActivityMasterSL _activityMasterSL;

        public VenuesController(ILogger<VenuesController> logger, VenueSL venueSL, ActivityMasterSL activityMasterSL)
        {
            _venueSL = venueSL;
            _activityMasterSL = activityMasterSL;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into HomeController");
        }

        // GET: Venues
        public async Task<IActionResult> Index()
        {
            return View(_venueSL.AllVenue().ToList());
        }

        // GET: Venues/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var obj = _venueSL.GetVenue(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: Venues/Create
        public IActionResult Create()
        {
            var TypeDropDown = _activityMasterSL.AllActivity().ToList();

            ViewBag.TypeDropDown = TypeDropDown;

            return View();
        }

        // POST: Venues/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Venue venue)
        {
            var result = _venueSL.CreateVenue(venue);
            if (result == "Success")
                return RedirectToAction("Index");
            else if (result == "Error - Venue already exists")
                ViewBag.Error = result;

            var TypeDropDown = _activityMasterSL.AllActivity().ToList();

            ViewBag.TypeDropDown = TypeDropDown;

            return View(venue);
        }

        public IActionResult OverLimit()
        {
            return View();
        }

        public IActionResult Duplicate()
        {
            return View();
        }

        // GET: Venues/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var obj = _venueSL.GetVenue(id);

            var TypeDropDown = _activityMasterSL.AllActivity().ToList();

            ViewBag.TypeDropDown = TypeDropDown;
            return View(obj);
        }

        // POST: Venues/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Venue venue)
        {
            var TypeDropDown = _activityMasterSL.AllActivity().ToList();

            ViewBag.TypeDropDown = TypeDropDown;

            var result = _venueSL.UpdateVenue(id, venue);
            if (result == "Success")
                return RedirectToAction("Index");
            else if (result == "Error - Venue already exists")
                ViewBag.Error = result;
            return View(venue);
        }

        // GET: Venues/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var obj = _venueSL.GetVenue(id);
            return View(obj);
        }

        // POST: Venues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = _venueSL.DeleteVenue(_venueSL.GetVenue(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
