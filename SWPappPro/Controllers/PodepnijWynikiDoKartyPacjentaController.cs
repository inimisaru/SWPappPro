using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class PodepnijWynikiDoKartyPacjentaController : Controller
    {
        /// <summary>
        /// Funkcja służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony PodepnijWynikiDoKartyPacjenta</returns>
        public ActionResult PodepnijWynikiDoKartyPacjenta()
        {
            return View();
        }
        /// <summary>
        /// Funkcja formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony PodepnijWynikiDoKartyPacjentaWynik</returns>
        [HttpPost]
        public ActionResult PodepnijWynikiDoKartyPacjentaZatwierdz()
        {
            return View("PodepnijWynikiDoKartyPacjentaWynik");
        }
        /// <summary>
        /// Funkcja służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony PodepnijWynikiDoKartyPacjentaWynik</returns>
        public ActionResult PodepnijWynikiDoKartyPacjentaWynik()
        {
            return View();
        }
    }
}