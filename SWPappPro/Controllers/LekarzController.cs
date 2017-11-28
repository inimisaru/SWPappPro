using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class LekarzController : Controller
    {
        // GET: Lekarz
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Wizyty()
        {
            return View();
        }
        public ActionResult Konsultacje()
        {
            return View();
        }
        public ActionResult Pacjenci()
        {
            return View();
        }
        public ActionResult Profil()
        {
            return View();
        }
    }
}