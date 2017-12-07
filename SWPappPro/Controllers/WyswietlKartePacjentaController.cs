using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    /// <summary>
    /// Autor: Dawid Stefański
    /// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
    /// </summary>
    public class WyswietlKartePacjentaController : Controller
    {
        /// <summary>
        /// Metoda służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony WyswietlKartePacjenta</returns>
        public ActionResult WyswietlKartePacjenta()
        {
            return View("WyswietlKartePacjenta");
        }
        /// <summary>
        /// Metoda formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony WyswietlKartePacjentaWynik</returns>
        [HttpPost]
        public ActionResult WyswietlKartePacjentaZatwierdz()
        {
            return View("WyswietlKartePacjentaWynik");
        }
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony WyswietlKartePacjenta</returns>
        public ActionResult WyswietlKartePacjentaWynik()
        {
            return View();
        }
    }
}