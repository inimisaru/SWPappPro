using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class ZamowWizyteKonsultacyjnaController : Controller
    {
        // GET: ZamowWizyteKonsultacyjna
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ZamowWizyteKonsultacyjna()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ZamowWizyteKonsultacyjnaZatwierdz()
        {
            return View("ZamowWizyteKonsultacyjnaWynik");
        }
    }
}