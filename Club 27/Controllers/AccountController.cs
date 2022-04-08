#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Club_27.Models;
using System.Web;
using Club27.Models;


namespace Club_27.Controllers
{
    public class AccountController : Controller
    {

        private readonly Club27DBContext _context;
        public AccountController(Club27DBContext context)
        {
            _context = context;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            if (ModelState.IsValid)
            {
                var obj = _context.Users.Where(a => a.Username.Equals(objUser.Username) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                if (obj != null)
                {
                    HttpContext.Session.SetString("Username", obj.Username);
                    HttpContext.Session.SetString("Password", obj.Password);
                    return RedirectToAction("Index","Home");
                }

            }
            return View(objUser);
        }

        //public ActionResult UserDashBoard()
        //{
        //    if (Session["UserID"] != null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }
        //}
    }
}