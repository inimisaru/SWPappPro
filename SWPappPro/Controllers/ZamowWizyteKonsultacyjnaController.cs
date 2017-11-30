using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class ZamowWizyteKonsultacyjnaController : Controller
    {
        /// <summary>
        /// Funkcja służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony ZamowWizyteKonsultacyjna</returns>
        public ActionResult ZamowWizyteKonsultacyjna()
        {
            return View();
        }
        /// <summary>
        /// Funkcja formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony ZamowWizyteKonsultacyjnaWynik</returns>
        [HttpPost]
        public ActionResult ZamowWizyteKonsultacyjnaZatwierdz()
        {
            return View("ZamowWizyteKonsultacyjnaWynik");
        }
    }
}