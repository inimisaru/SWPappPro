using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    /// <summary>
    /// Autor: Dawid Stefański
    /// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
    /// </summary>
    public class PodejrzyjSwojaKartePacjentaController : Controller
    {
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony PodejrzyjSwojaKartePacjenta</returns>
        public ActionResult PodejrzyjSwojaKartePacjenta()
        {
            return View();
        }
    }
}