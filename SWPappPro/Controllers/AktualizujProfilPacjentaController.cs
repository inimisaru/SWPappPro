using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class AktualizujProfilPacjentaController : Controller
    {
        /// <summary>
        /// Glowna metoda kontrolera zwracajaca strone z formularzem do aktualizacji danych pacjenta
        /// </summary>
        /// <returns>strona AktualizujProfilPacjenta</returns>
        public ActionResult AktualizujProfilPacjenta()
        {
            return View();
        }
        /// <summary>
        /// Metoda wywoływana metoda POST przez formularz na stronie AktualizujProfilPacjenta
        /// W wyniku jej wykonania zostana zaktualizowane dane pacjenta w bazie danych.
        /// Metoda zwraca strone AktualizujProfilPacjentaWynik na ktorej znajduje sie informacja o wyniku wykonania.
        /// </summary>
        /// <returns>strona AktualizujProfilPacjentaWynik</returns>
        public ActionResult AktualizujProfilPacjentaZatwierdz()
        {
            return View("AktualizujProfilPacjentaWynik");
        }
    }
}