using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class WyswietlHistorieWizytController : Controller
    {
        /// <summary>
        /// Funkcja służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony WyswietlHistorieWizyt</returns>
        public ActionResult WyswietlHistorieWizyt()
        {
            return View();
        }
    }
}