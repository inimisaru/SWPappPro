using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class ZamowWizyteDomowaController : Controller
    {
        /// <summary>
        /// Funkcja służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony ZamowWizyteDomowa</returns>
        public ActionResult ZamowWizyteDomowa()
        {
            return View();
        }
        /// <summary>
        /// Funkcja formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony ZamowWizyteDomowaWynik</returns>
        [HttpPost]
        public ActionResult ZamowWizyteDomowaZatwierdz()
        {
            return View("ZamowWizyteDomowaWynik");
        }
    }
}