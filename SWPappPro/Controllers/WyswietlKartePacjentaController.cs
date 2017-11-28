using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class WyswietlKartePacjentaController : Controller
    {
        // GET: WyswietlKartePacjenta
        public ActionResult Index()
        {
            return View();
        }
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