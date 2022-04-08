using Club_27.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Club_27.ViewModels;
using Club_27.Services;

namespace Club_27.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly Club27DBContext _context;

        private readonly EnrollmentSL enrollmentSL;
        public HomeController(Club27DBContext context , ILogger<HomeController> logger, EnrollmentSL enrollmentSLobject)
        {
            enrollmentSL = enrollmentSLobject;
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        
        {
            var objEnrollmentList = _context.Enrollments.Include(x => x.Employee).Include(x => x.Activity).ToList();
            //var objEnrollmentList = enrollmentSL.AllEnrollment();
                 
            var employeeGroupedActivityList = objEnrollmentList.GroupBy(c => c.Employee.EmployeeID)
                 .Select(d => new EnrollmentViewModel
                 {
                     EmployeeVM = objEnrollmentList.Where(y => y.Employee.EmployeeID == d.Key).Select(y => y.Employee).FirstOrDefault(),
                     ActivityListVM =  d.Select(e => e.Activity).ToList()
                 });

            return View(employeeGroupedActivityList);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}