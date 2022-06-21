using Club_27.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Club_27.Controllers
{
    public class RoleController : Controller
    {
        private readonly Club27DBContext _context;
        private RoleManager<ApplicationRole> _roleManager;
        public RoleController(Club27DBContext context, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;    
            _roleManager = roleManager;
        }

        public ActionResult Index()
        {
            List<Role> list = new List<Role>();
            //List<ApplicationRole> obj = _context.Roles.ToList();

            //foreach (var role in RoleManager<IdentityRole>.Roles)
            //    list.Add(new IdentityRole(role));
            return View(list);
        }
    }
}
