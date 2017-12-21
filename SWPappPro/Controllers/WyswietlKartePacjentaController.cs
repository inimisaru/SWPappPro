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
            /*

            KARTA_PACJENTA kARTA_PACJENTA = db.KARTA_PACJENTA.Find(id);
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bADANIE = db.BADANIE.Include(b => b.KARTA_PACJENTA).Include(b => b.LEKARZ).Where(b => b.KARTA_PACJENTA_ID==kARTA_PACJENTA.KARTA_PACJENTA_ID);
            return View(bADANIE.ToList());
            */
            //Stworzenie nowego obiektu modelu KalendarzModel

            var viewModel = new KartaBadanieModel();

            viewModel.Karta_pacjenta = db.KARTA_PACJENTA.Where(k => k.KARTA_PACJENTA_ID==id);

            viewModel.Badanie = db.BADANIE.Where(b => b.KARTA_PACJENTA_ID == id);

            return View(viewModel);

        }
    }
}