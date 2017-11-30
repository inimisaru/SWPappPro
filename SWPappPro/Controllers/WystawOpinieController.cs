using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class WystawOpinieController : Controller
    {
        /// <summary>
        /// Funkcja służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony WystawOpinie</returns>
        public ActionResult WystawOpinie()
        {
            return View();
        }
        /// <summary>
        /// Funkcja formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony WystawOpinieWynik</returns>
        [HttpPost]
        public ActionResult WystawOpinieZatwierdz()
        {
            
            return View("WystawOpinieWynik");
        }
    }
}