using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using SWPappPro.Models;

namespace SWPappPro.Controllers
{
    /// <summary>
    /// Autor: Bartłomiej Balak
    /// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
    /// </summary>
    public class PodepnijWynikiDoKartyPacjentaController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony PodepnijWynikiDoKartyPacjenta</returns>
        public ActionResult PodepnijWynikiDoKartyPacjenta()
        {
            return View(db.PACJENT.ToList());
        }
        /// <summary>
        /// Metoda formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony PodepnijWynikiDoKartyPacjentaWynik</returns>
        /// 
        public ActionResult PodepnijWynikiDoKartyPacjentaFormularz(int? id)
        {
            Session["id_pac"] = id;
            return View();
        }
        /// <summary>
        /// Metoda typu POST zapisująca do bazy danych wyniki
        /// </summary>
        /// <param name="bADANIE"> obiekt BADANIE utworzony przy wypełnianiu formualarza</param>
        /// <returns>Widok PodepnijWynikiDoKartyPacjentaWynik</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PodepnijWynikiDoKartyPacjentaFormularz([Bind(Include = "DATA_BADANIA,RODZAJ,WYNIK,BADANIE_ID,KARTA_PACJENTA_ID,LEKARZ_ZLECAJACY")] BADANIE bADANIE)
        {
            //Wyszukaj obiekt PACJENT o wskazanym ID
            PACJENT pacjent = db.PACJENT.Find((int?)Session["id_pac"]);
            //Wyszukaj obiekt KARTA_PACJENTA o wskazanym ID
            KARTA_PACJENTA Karta = db.KARTA_PACJENTA.Where(k => k.WLASCICIEL == pacjent.PACJENT_ID).FirstOrDefault();
            
            if (ModelState.IsValid)
            {
                //Uzupełnienie obiektu BADANIE
                bADANIE.KARTA_PACJENTA_ID = Karta.KARTA_PACJENTA_ID;
                bADANIE.LEKARZ_ZLECAJACY = (int?)Session["id"];
                //Zapisanie rekordu do bazy danych
                db.BADANIE.Add(bADANIE);
                db.SaveChanges();
                return View("PodepnijWynikiDoKartyPacjentaWynik");
            }

            ViewBag.KARTA_PACJENTA_ID = new SelectList(db.KARTA_PACJENTA, "KARTA_PACJENTA_ID", "NUMER_KARTY", bADANIE.KARTA_PACJENTA_ID);
            ViewBag.LEKARZ_ZLECAJACY = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", bADANIE.LEKARZ_ZLECAJACY);
            return View(bADANIE);
        }
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony PodepnijWynikiDoKartyPacjentaWynik</returns>
        public ActionResult PodepnijWynikiDoKartyPacjentaWynik()
        {
            return View();
        }
    }
}