using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{/// <summary>
/// Autor: Bartłomiej Balak
/// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
/// </summary>
    public class UmowWizyteController : Controller
    {
        // GET: UmowWizyte
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony UmowWizyte</returns>
        public ActionResult UmowWizyte()
        {
            return View();
        }
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony UmowWizyteKon</returns>
        public ActionResult UmowWizyteKon()
        {
            return View();
        }
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony UmowWizyteDom</returns>
        public ActionResult UmowWizyteDom()
        {
            return View();
        }
        /// <summary>
        /// Metoda formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony UmowWizyteWynik</returns>
        [HttpPost]
        public ActionResult UmowWizyteKonZatwierdz()
        {
            return View("UmowWizyteWynik");
        }
        /// <summary>
        /// Funkcja formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony UmowWizyteWynik</returns>
        [HttpPost]
        public ActionResult UmowWizyteDomZatwierdz()
        {
            return View("UmowWizyteWynik");
        }
    }
}