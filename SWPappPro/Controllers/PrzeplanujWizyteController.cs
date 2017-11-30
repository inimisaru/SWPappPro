using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class PrzeplanujWizyteController : Controller
    {
        /// <summary>
        /// Funkcja służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony PrzeplanujWizyte</returns>
        public ActionResult PrzeplanujWizyte()
        {
            return View();
        }
        /// <summary>
        /// Funkcja formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony PrzeplanujWizyteFormularz</returns>
        [HttpPost]
        public ActionResult PrzeplanujWizyteWybor()
        {
            return View("PrzeplanujWizyteFormularz");
        }
        /// <summary>
        /// Funkcja formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony PrzeplanujWizyteWynik</returns>
        [HttpPost]
        public ActionResult PrzeplanujWizyteZatwierdz()
        {
            return View("PrzeplanujWizyteWynik");
        }
    }
}