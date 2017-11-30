using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class PrzeplanujWizyteController : Controller
    {
        public ActionResult PrzeplanujWizyte()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PrzeplanujWizyteWybor()
        {
            return View("PrzeplanujWizyteFormularz");
        }
        [HttpPost]
        public ActionResult PrzeplanujWizyteZatwierdz()
        {
            return View("PrzeplanujWizyteWynik");
        }
    }
}