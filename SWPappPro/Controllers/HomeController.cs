using SWPappPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {  
            if (Session["login"] == null)
            {
                return View("Login");
            }
            else
            {
                return View("Home");
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult TerminarzView()
        {
            return View();

        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(users entity)
        {
            
            var db = new SWPappDBEntities5();
            var pass = db.users.Where(s => s.username == entity.username.Trim()).FirstOrDefault();
            if (pass != null) { 
            if (entity.password.Equals(pass.password.Trim()))
            {
                Session["login"] = pass.username;
                Session["typ"] = pass.type;
                return View("Home");
                
            }
            else
            {
                    ViewBag.Message = "Wprowadziles zle dane!";
                    return View("Fail");
                
            }
            }
            else
            {
                ViewBag.Message = "Wprowadziles zle dane!";
                    return View("Fail");
            }
        }
        public ActionResult Logout()
        {
            Session["login"] = null;
            return View("Login");
        }
    }
}