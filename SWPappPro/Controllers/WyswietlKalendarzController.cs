using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class WyswietlKalendarzController : Controller
    {
        /// <summary>
        /// Funkcja służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony WyswietlKalendarz</returns>
        public ActionResult WyswietlKalendarz()
        {
            return View();
        }
    }
}