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
    public class PrzeplanujWizyteController : Controller
    {
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony PrzeplanujWizyte</returns>
        public ActionResult PrzeplanujWizyte()
        {
            return View();
        }
        /// <summary>
        /// Metoda formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony PrzeplanujWizyteFormularz</returns>
        [HttpPost]
        public ActionResult PrzeplanujWizyteWybor()
        {
            return View("PrzeplanujWizyteFormularz");
        }
        /// <summary>
        /// Metoda formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony PrzeplanujWizyteWynik</returns>
        [HttpPost]
        public ActionResult PrzeplanujWizyteZatwierdz()
        {
            return View("PrzeplanujWizyteWynik");
        }
    }
}