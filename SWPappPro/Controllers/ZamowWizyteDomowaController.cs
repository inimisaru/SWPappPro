using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class ZamowWizyteDomowaController : Controller
    {
        // GET: ZamowWizyteDomowa
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ZamowWizyteDomowa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ZamowWizyteDomowaZatwierdz()
        {
            return View("ZamowWizyteDomowaWynik");
        }
    }
}