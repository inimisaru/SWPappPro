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
    public class ZamowWizyteKonsultacyjnaController : Controller
    {
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony ZamowWizyteKonsultacyjna</returns>
        public ActionResult ZamowWizyteKonsultacyjna()
        {
            return View();
        }
        /// <summary>
        /// Metoda formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony ZamowWizyteKonsultacyjnaWynik</returns>
        [HttpPost]
        public ActionResult ZamowWizyteKonsultacyjnaZatwierdz()
        {
            return View("ZamowWizyteKonsultacyjnaWynik");
        }
    }
}