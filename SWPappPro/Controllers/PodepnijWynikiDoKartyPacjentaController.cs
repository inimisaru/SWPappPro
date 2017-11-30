using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    /// <summary>
    /// Autor: Bartłomiej Balak
    /// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
    /// </summary>
    public class PodepnijWynikiDoKartyPacjentaController : Controller
    {
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony PodepnijWynikiDoKartyPacjenta</returns>
        public ActionResult PodepnijWynikiDoKartyPacjenta()
        {
            return View();
        }
        /// <summary>
        /// Metoda formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony PodepnijWynikiDoKartyPacjentaWynik</returns>
        [HttpPost]
        public ActionResult PodepnijWynikiDoKartyPacjentaZatwierdz()
        {
            return View("PodepnijWynikiDoKartyPacjentaWynik");
        }
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony PodepnijWynikiDoKartyPacjentaWynik</returns>
        public ActionResult PodepnijWynikiDoKartyPacjentaWynik()
        {
            return View();
        }
    }
}