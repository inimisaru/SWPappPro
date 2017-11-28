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
            //Wywołanie metody sprawdzajacej dane logowania uzytkownika, metoda zwraca wartosc true/false 
            //w zaleznosci od wyniku operacji walidacji.
            if (entity.ValidateUser(entity, this.HttpContext))
            {
                if (Session["typ"].Equals("lekarz")) return RedirectToAction("Index", "Lekarz");
                else return RedirectToAction("Index", "Pacjent");
            }

            else return View("Fail");
        }

        public ActionResult Logout()
        {
            Session["login"] = null;
            return View("Login");
        }

    }
}