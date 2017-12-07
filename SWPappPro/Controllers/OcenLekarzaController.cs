using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{/// <summary>
/// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
/// </summary>
    public class OcenLekarzaController : Controller
    {
        // GET: OcenLekarza
        /// <summary>
        /// Funkcja służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony Index</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}