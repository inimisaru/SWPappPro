using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class PacjentController : Controller
    {
        // GET: Pacjent
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
        public ActionResult Profil()
        {
            return View();
        }
    }
}