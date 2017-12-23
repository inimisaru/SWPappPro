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
    /// Autor: Dawid Stefański
    /// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
    /// </summary>
    public class WyswietlKartePacjentaController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();
        /// <summary>
        /// Metoda służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony WyswietlKartePacjenta</returns>
        public ActionResult WyswietlKartePacjenta()
        {
            return View(db.PACJENT.ToList());
            //return View("WyswietlKartePacjenta");
        }
        /// <summary>
        /// Metoda formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony WyswietlKartePacjentaWynik</returns>
        [HttpPost]
        public ActionResult WyswietlKartePacjentaZatwierdz()
        {
            return View("WyswietlKartePacjentaWynik");
        }
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony WyswietlKartePacjenta</returns>
        public ActionResult WyswietlKartePacjentaWynik(int? id)
        {
            //utworzenie nowego obiektu viewModel
            var viewModel = new KartaBadanieModel();
            //wstawienie do obiektu viewModel obiektu typu karta_pacjenta o identyfikatorze id
            viewModel.Karta_pacjenta = db.KARTA_PACJENTA.Where(k => k.KARTA_PACJENTA_ID==id);
            //wstawienie do obiektu viewModel obiektów typu badanie należących do karty pacjenta
            viewModel.Badanie = db.BADANIE.Where(b => b.KARTA_PACJENTA_ID == id);

            return View(viewModel);

        }
    }
}