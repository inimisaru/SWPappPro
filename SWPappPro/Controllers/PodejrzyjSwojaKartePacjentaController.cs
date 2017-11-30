using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class PodejrzyjSwojaKartePacjentaController : Controller
    {
        /// <summary>
        /// Funkcja służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony PodejrzyjSwojaKartePacjenta</returns>
        public ActionResult PodejrzyjSwojaKartePacjenta()
        {
            return View();
        }
    }
}