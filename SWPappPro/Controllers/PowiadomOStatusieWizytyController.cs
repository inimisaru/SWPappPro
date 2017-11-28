using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class PowiadomOStatusieWizytyController : Controller
    {
        // GET: PowiadomOStatusieWizyty
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PowiadomOStatusieWizyty()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PowiadomOStatusieWizytyZatwierdz()
        {
            return View("PowiadomOStatusieWizytyWynik");
        }
    }
}