using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class PodepnijWynikiDoKartyPacjentaController : Controller
    {
        // GET: PodepnijWynikiDoKartyPacjenta
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PodepnijWynikiDoKartyPacjenta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PodepnijWynikiDoKartyPacjentaZatwierdz()
        {
            return View("PodepnijWynikiDoKartyPacjentaWynik");
        }
        public ActionResult PodepnijWynikiDoKartyPacjentaWynik()
        {
            return View();
        }
    }
}