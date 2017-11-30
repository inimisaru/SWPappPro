using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class AktualizujSwojProfilController : Controller
    {
        public ActionResult AktualizujSwojProfil()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AktualizujSwojProfilZatwierdz()
        {
            return View("AktualizujSwojProfilWynik");
        }
    }
}