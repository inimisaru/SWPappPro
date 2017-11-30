using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    /// <summary>
    /// Autor: Bartosz Burak
    /// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
    /// </summary>
    public class ZamowWizyteDomowaController : Controller
    {
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony ZamowWizyteDomowa</returns>
        public ActionResult ZamowWizyteDomowa()
        {
            return View();
        }
        /// <summary>
        /// Metoda formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony ZamowWizyteDomowaWynik</returns>
        [HttpPost]
        public ActionResult ZamowWizyteDomowaZatwierdz()
        {
            return View("ZamowWizyteDomowaWynik");
        }
    }
}