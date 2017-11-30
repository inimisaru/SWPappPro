using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class AktualizujProfilPacjentaController : Controller
    {
        public ActionResult AktualizujProfilPacjenta()
        {
            return View();
        }
        public ActionResult AktualizujProfilPacjentaZatwierdz()
        {
            return View("AktualizujProfilPacjentaWynik");
        }
    }
}