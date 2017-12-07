using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    /// <summary>
    /// Autor: Bartłomiej Balak
    /// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
    /// </summary>
    public class DodajWolnyTerminWizytyController : Controller
    {
        /// <summary>
        /// Glowna metoda kontrolera zwracajaca strone z formularzem wprowadzenia nowego terminu wizyty dla lekarza.
        /// </summary>
        /// <returns>strona DodajWolnyTerminWizyty</returns>
        public ActionResult DodajWolnyTerminWizyty()
        {
            return View();
        }
        /// <summary>
        /// Metoda wywoływana metoda POST przez formularz na stronie DodajWolnyTerminWizyty
        /// W wyniku jej wykonania zostanie dodany nowy termin wizyty.
        /// Metoda zwraca strone DodajWolnyTerminWizytyWynik na ktorej znajduje sie informacja o wyniku wykonania.
        /// </summary>
        /// <returns>strona DodajWolnyTerminWizytyWynik</returns>
        [HttpPost]
        public ActionResult DodajWolnyTerminWizytyZatwierdz()
        {
            return View("DodajWolnyTerminWizytyWynik");
        }
    }
}