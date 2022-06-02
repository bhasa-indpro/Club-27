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
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Club_27.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly Club27DBContext _context;

        private readonly EnrollmentSL enrollmentSL;
        private readonly IMapper _mapper;
        public HomeController(Club27DBContext context , ILogger<HomeController> logger, EnrollmentSL enrollmentSLobject, IMapper mapper)
        {
            enrollmentSL = enrollmentSLobject;
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()        
        {
            var objEnrollmentList = _context.Enrollments.Include(x => x.Employee).Include(x => x.Activity).ToList();
            //var objEnrollmentList = enrollmentSL.AllEnrollment();
                 
            //var employeeGroupedActivityList = objEnrollmentList.GroupBy(c => c.Employee.EmployeeID)
            //     .Select(d => new EnrollmentViewModel
            //     {
            //         EmployeeVM = objEnrollmentList.Where(y => y.Employee.EmployeeID == d.Key).Select(y => y.Employee).FirstOrDefault(),
            //         ActivityListVM =  d.Select(e => e.Activity).ToList()
            //     });
            
            //AutoMapper Part
            var item = _context.Enrollments.Include(x => x.Employee).Include(x => x.Activity).ToList();
            var mappedItem = _mapper.Map<List<EnrollmentViewModelAutoMapper>>(item);

            //var employeeGroupedActivityList = item.GroupBy(c => c.Employee.EmployeeID)
            //     .Select(d => new EnrollmentViewModelAutoMapper
            //     {
            //         EmployeeID = item.Where(y => y.EmployeeID == d.Key),
            //         ActivityList = d.Select(e => e.Activity).ToList()
            //     });

            var enrollmentGroupByEmployee = item.GroupBy(c => c.Employee.EmployeeName)
                .Select(d => new EnrollmentViewModelAutoMapper
                {
                    EmployeeName = d.Key,
                    ActivityList = d.Select(e => e.Activity.ActivityName).ToList()
                });

            //return View(employeeGroupedActivityList);
            return View(enrollmentGroupByEmployee);

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