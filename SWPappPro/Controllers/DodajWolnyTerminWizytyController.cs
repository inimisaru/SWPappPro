using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class DodajWolnyTerminWizytyController : Controller
    {
        // GET: DodajWolnyTerminWizyty
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DodajWolnyTerminWizyty()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DodajWolnyTerminWizytyZatwierdz()
        {
            return View("DodajWolnyTerminWizytyWynik");
        }
    }
}