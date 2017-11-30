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
    public class PowiadomOStatusieWizytyController : Controller
    {
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony .
        /// </summary>
        /// <returns>widok strony PowiadomOStatusieWizyty</returns>
        public ActionResult PowiadomOStatusieWizyty()
        {
            return View();
        }
        /// <summary>
        /// Metoda formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony PowiadomOStatusieWizytyWynik</returns>
        [HttpPost]
        public ActionResult PowiadomOStatusieWizytyZatwierdz()
        {
            return View("PowiadomOStatusieWizytyWynik");
        }
    }
}