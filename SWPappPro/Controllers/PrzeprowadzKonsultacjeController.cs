using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class PrzeprowadzKonsultacjeController : Controller
    {
        // GET: PrzeprowadzKonsultacje
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