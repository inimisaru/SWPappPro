using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWPappPro.Models;
using System.Data.Entity;

namespace SWPappPro.Controllers
{ 
    /// <summary>
    /// Autor: Michał Fijas
    /// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
    /// </summary>
    public class AktualizujProfilPacjentaController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();
        /// <summary>
        /// Glowna metoda kontrolera zwracajaca strone z formularzem do aktualizacji danych pacjenta
        /// </summary>
        /// <returns>strona AktualizujProfilPacjenta</returns>
        public ActionResult AktualizujProfilPacjenta()
        {
            int id = (int)Session["id"];
            PACJENT pACJENT = db.PACJENT.Find(id);
            return View(pACJENT);
        }
        /// <summary>
        /// Metoda wywoływana metoda POST przez formularz na stronie AktualizujProfilPacjenta
        /// W wyniku jej wykonania zostana zaktualizowane dane pacjenta w bazie danych.
        /// Metoda zwraca strone AktualizujProfilPacjentaWynik na ktorej znajduje sie informacja o wyniku wykonania.
        /// </summary>
        /// <returns>strona AktualizujProfilPacjentaWynik</returns>
        /*
        public ActionResult AktualizujProfilPacjentaZatwierdz()
        {

            return View("AktualizujProfilPacjentaWynik");

        }
        */
        [HttpPost]
        public ActionResult AktualizujProfilPacjentaZatwierdz([Bind(Include = "PACJENT_ID,IMIE,NAZWISKO,PESEL,DATA_URODZENIA,MIEJSCE_URODZENIA,ULICA_ZAMIESZKANIA,MIEJSCOWOSC,KOD_POCZTOWY,ADRES_E_MAIL,NR_TELEFONU,HASLO")] PACJENT pACJENT)
        {
            if (ModelState.IsValid)
            {
                //oznacz jako zmienione
                db.Entry(pACJENT).State = EntityState.Modified;
                //zapisz zmiany
                db.SaveChanges();
                //zwrócenie widoku AktualizujSwojProfil
                return View("AktualizujProfilPacjentaWynik");
            }
            return View("AktualizujProfilPacjenta");
        }

    }
}