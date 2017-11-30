using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class WyswietlKartePacjentaController : Controller
    {
        public ActionResult WyswietlKartePacjenta()
        {
            return View("WyswietlKartePacjenta");
        }
        [HttpPost]
        public ActionResult WyswietlKartePacjentaZatwierdz()
        {
            return View("WyswietlKartePacjentaWynik");
        }
            public ActionResult WyswietlKartePacjentaWynik()
        {
            return View();
        }
    }
}