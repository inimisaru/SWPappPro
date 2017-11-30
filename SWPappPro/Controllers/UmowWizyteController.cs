using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class UmowWizyteController : Controller
    {
        // GET: UmowWizyte
        public ActionResult UmowWizyte()
        {
            return View();
        }
        public ActionResult UmowWizyteKon()
        {
            return View();
        }
        public ActionResult UmowWizyteDom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UmowWizyteKonZatwierdz()
        {
            return View("UmowWizyteWynik");
        }
        [HttpPost]
        public ActionResult UmowWizyteDomZatwierdz()
        {
            return View("UmowWizyteWynik");
        }
    }
}