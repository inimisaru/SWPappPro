using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    /// <summary>
    /// Autor: Michał Fijas
    /// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
    /// </summary>
    public class AktualizujSwojProfilController : Controller
    {
        /// <summary>
        /// Glowna metoda kontrolera zwracajaca strone z formularzem do aktualizacji profilu lekarza
        /// </summary>
        /// <returns>strona AktualizujSwojProfil</returns>
        public ActionResult AktualizujSwojProfil()
        {
            return View();
        }
        /// <summary>
        /// Metoda wywoływana metoda POST przez formularz na stronie AktualizujSwojProfil
        /// W wyniku jej wykonania zostana zaktualizowane dane lekarza w bazie danych.
        /// Metoda zwraca strone AktualizujSwojProfilWynik na ktorej znajduje sie informacja o wyniku wykonania.
        /// </summary>
        /// <returns>strona AktualizujSwojProfilWynik</returns>
        [HttpPost]
        public ActionResult AktualizujSwojProfilZatwierdz()
        {
            return View("AktualizujSwojProfilWynik");
        }
    }
}