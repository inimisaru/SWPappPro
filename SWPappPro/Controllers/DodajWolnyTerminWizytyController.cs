using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SWPappPro.Models;

namespace SWPappPro.Controllers
{
    /// <summary>
    /// Autor: Bartłomiej Balak
    /// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
    /// </summary>
    public class DodajWolnyTerminWizytyController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();
        /// <summary>
        /// Glowna metoda kontrolera zwracajaca strone z formularzem wprowadzenia nowego terminu wizyty dla lekarza.
        /// </summary>
        /// <returns>strona DodajWolnyTerminWizyty</returns>
        public ActionResult DodajWolnyTerminWizyty()
        {
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE");
            return View();
        }
        /// <summary>
        /// Metoda wywoływana metoda POST przez formularz na stronie DodajWolnyTerminWizyty
        /// W wyniku jej wykonania zostanie dodany nowy termin wizyty.
        /// Metoda zwraca strone DodajWolnyTerminWizytyWynik na ktorej znajduje sie informacja o wyniku wykonania.
        /// </summary>
        /// <returns>strona DodajWolnyTerminWizytyWynik</returns>
        [HttpPost]
        public ActionResult DodajWolnyTerminWizytyZatwierdz([Bind(Include = "TERMINARZ_ID,DATA,GODZINA,LEKARZ_ID")] TERMINARZ tERMINARZ)
        {
            tERMINARZ.LEKARZ_ID = (int)Session["id"];
            if (ModelState.IsValid)
            {
                db.TERMINARZ.Add(tERMINARZ);
                db.SaveChanges();
                return View("DodajWolnyTerminWizytyWynik");
            }
            return View("DodajWolnyTerminWizyty");
        }
    }
}