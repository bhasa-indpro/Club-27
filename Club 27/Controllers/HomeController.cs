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
using Newtonsoft.Json;

namespace Club_27.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

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
           
            
            //AutoMapper Part
            var item = _context.Enrollments.Include(x => x.Employee).Include(x => x.Activity).ToList();
            var mappedItem = _mapper.Map<List<EnrollmentViewModelAutoMapper>>(item);


            var enrollmentGroupByEmployee = mappedItem.GroupBy(c => c.EmployeeName)
             .Select(d => new EnrollmentViewModelAutoMapper
             {
                 EmployeeName = d.Key,
                 ActivityNameList = d.Select(e => e.ActivityName).ToList()
             });
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        public ActionResult ActivityChart()
        {
            return View();
        }

        public JsonResult ActivityChartData()
        {
            var item = _context.Enrollments.Include(x => x.Employee).Include(x => x.Activity).ToList();
            var mappedItem = _mapper.Map<List<EnrollmentViewModelAutoMapper>>(item);

            //EnrollmentViewModelAutoMapper vmobj = new EnrollmentViewModelAutoMapper();

            //var allActivity = _context.ActivityMasters.Select(x=>x.ActivityName).ToList();
            //foreach(var i in allActivity)
            //{
            //    ActivityFlag flagListObj = new ActivityFlag();
            //    flagListObj.ActName = i;
            //    flagListObj.FlagValue = 0;
            //    vmobj.ActivityFlagList.Add(flagListObj);
            //}

            var enrollmentGroupByEmployee = mappedItem.GroupBy(c => c.EmployeeName)
             .Select(d => new EnrollmentViewModelAutoMapper
             {
                 EmployeeName = d.Key,
                 ActivityNameList = d.Select(e => e.ActivityName).ToList(),
                 ActivityCount = d.Select(f=>f.ActivityNameList).Count(),
                 ActivityFlagList = FlagMod (d.Select(g=>g.ActivityName).ToList())
             });

            return Json(enrollmentGroupByEmployee);
            //return View(Json(enrollmentGroupByEmployee));
        }

        public List<ActivityFlag> FlagMod(List<string> ActNameList)
        {
            List<ActivityFlag> result = new List<ActivityFlag>();
            var allActivity = _context.ActivityMasters.Select(x=>x.ActivityName).ToList();

            foreach (var i in allActivity)
            {
                result.Add(new ActivityFlag { ActName = i , FlagValue = 0});
            }

            foreach (var i in result)
            {
                foreach (var j in ActNameList)
                {
                    if(i.ActName == j)
                    {
                        //result.Add(new ActivityFlag { ActName = i.ActName , FlagValue = 1});
                        i.FlagValue = 1;
                        break;
                    }
                }
            }
            return result;
        }
    }
}