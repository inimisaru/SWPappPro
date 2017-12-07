using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using SWPappPro.Models;

namespace SWPappPro.Controllers
{

    /// <summary>
    /// Autor Dawid Stefański
    /// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
    /// </summary>
    public class WyswietlOpinieController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony z lista opinie zalogowanego lekarza
        /// </summary>
        /// <returns>widok strony WyswietlOpinie</returns>
        public ActionResult WyswietlOpinie()
        {
            //Pobierz id ze zmiennej sesji
            int id = (int)Session["id"];
            //Pobierz opinie dla lekarza o identyfikatorze id
            var oPINIA = db.OPINIA.Where(s => s.LEKARZ_ID==id).Include(o => o.LEKARZ).Include(o => o.PACJENT);
            //Zwróc listę opinii do widoku
            return View(oPINIA.ToList());
        }
    }
}