using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using SWPappPro.Models;

namespace SWPappPro.Controllers
{/// <summary>
/// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
/// </summary>
    public class OcenLekarzaController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();
        // GET: OcenLekarza
        /// <summary>
        /// Funkcja służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony Index</returns>
        public ActionResult Index()
        {
            return View(db.LEKARZ.ToList());
        }
    }
}