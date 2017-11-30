using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class PowiadomOStatusieWizytyController : Controller
    {
        /// <summary>
        /// Funkcja służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony PowiadomOStatusieWizyty</returns>
        public ActionResult PowiadomOStatusieWizyty()
        {
            return View();
        }
        /// <summary>
        /// Funkcja formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony PowiadomOStatusieWizytyWynik</returns>
        [HttpPost]
        public ActionResult PowiadomOStatusieWizytyZatwierdz()
        {
            return View("PowiadomOStatusieWizytyWynik");
        }
    }
}