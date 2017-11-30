using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class OdpowiedzNaWezwanieDoWizytyDomowejController : Controller
    {
        public ActionResult OdpowiedzNaWezwanieDoWizytyDomowej()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OdpowiedzNaWezwanieDoWizytyDomowejZatwierdz()
        {
            return View("OdpowiedzNaWezwanieDoWizytyDomowejWynik");
        }

    }
}