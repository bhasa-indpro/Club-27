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
    public class BookingsController : Controller
    {
        private readonly ILogger<BookingsController> _logger;
        private readonly BookingSL _bookingSL;
        private readonly ActivityMasterSL _activityMasterSL;
        private readonly VenueSL _venueSL;

        public BookingsController(ILogger<BookingsController> logger, ActivityMasterSL activityMasterSL, VenueSL venueSL, BookingSL bookingSL)
        {
            _activityMasterSL = activityMasterSL;
            _venueSL = venueSL;
            _bookingSL = bookingSL;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into HomeController");
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            return View(_bookingSL.AllBooking().ToList());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var obj = _bookingSL.GetBooking(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            var venueDropDown = _venueSL.AllVenue().ToList();
            var activityDropDown = _activityMasterSL.AllActivity().ToList();

            ViewBag.venueDropDown = venueDropDown;
            ViewBag.activityDropDown = activityDropDown;

            return View();
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Booking booking)
        {
            var result = _bookingSL.CreateBooking(booking);
            if (result == "Success")
                return RedirectToAction("Index");
            else if (result == "Error - Duplicate Booking")
                ViewBag.Error = result;

            var venueDropDown = _venueSL.AllVenue().ToList();
            var activityDropDown = _activityMasterSL.AllActivity().ToList();

            ViewBag.venueDropDown = venueDropDown;
            ViewBag.activityDropDown = activityDropDown;

            return View(booking);            
        }

        public IActionResult OverLimit()
        {
            return View();
        }

        public IActionResult Duplicate()
        {
            return View();
        }
                
        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var obj = _bookingSL.GetBooking(id);

            var venueDropDown = _venueSL.AllVenue().ToList();
            var activityDropDown = _activityMasterSL.AllActivity().ToList();

            ViewBag.venueDropDown = venueDropDown;
            ViewBag.activityDropDown = activityDropDown;
            return View(obj);
        }

        // POST: Bookings/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Booking booking)
        {
            var venueDropDown = _venueSL.AllVenue().ToList();
            var activityDropDown = _activityMasterSL.AllActivity().ToList();

            ViewBag.venueDropDown = venueDropDown;
            ViewBag.activityDropDown = activityDropDown;

            var result = _bookingSL.UpdateBooking(id, booking);
            if (result == "Success")
                return RedirectToAction("Index");
            else if (result == "Error - Duplicate Booking")
                ViewBag.Error = result;
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var obj = _bookingSL.GetBooking(id);
            return View(obj);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = _bookingSL.DeleteBooking(_bookingSL.GetBooking(id));
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<JsonResult> GetVenueList(int id)
        {
            var venueList = _venueSL.AllVenue().Where(x => x.ActivityID == id).ToList();
            var venueDropDownItems = venueList.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.VenueName }).ToList();
            //var returnValue = Json(teamDropDownItems);
            return Json(venueDropDownItems);
        }
    }
}
