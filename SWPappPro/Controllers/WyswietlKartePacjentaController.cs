using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class WyswietlKartePacjentaController : Controller
    {
        /// <summary>
        /// Funkcja służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony WyswietlKartePacjenta</returns>
        public ActionResult WyswietlKartePacjenta()
        {
            return View("WyswietlKartePacjenta");
        }
        /// <summary>
        /// Funkcja formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony WyswietlKartePacjentaWynik</returns>
        [HttpPost]
        public ActionResult WyswietlKartePacjentaZatwierdz()
        {
            return View("WyswietlKartePacjentaWynik");
        }
        /// <summary>
        /// Funkcja służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony WyswietlKartePacjenta</returns>
        public ActionResult WyswietlKartePacjentaWynik()
        {
            return View();
        }
    }
}