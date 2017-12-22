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
    /// Autor: Bartosz Burak
    /// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
    /// </summary>
    public class WyswietlHistorieWizytController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony WyswietlHistorieWizyt</returns>
        public ActionResult WyswietlHistorieWizyt(int? wiz_k,int? wiz_d)
        {

            int id = (int)Session["id"];

            //Stworzenie nowego obiektu modelu KalendarzModel
            var viewModel = new KalendarzModel();

            //Załadowanie do Terminarza tabeli Terminarz
            viewModel.Terminarz = db.TERMINARZ
                .Include(i => i.WIZYTA_KONSULTACYJNA)
                .OrderBy(i => i.DATA);
            //Załadowanie Tabeli wizyta konsultacyjna
            viewModel.Wizyta_konsultacyjnaStala = db.WIZYTA_KONSULTACYJNA.Where(w => w.PACJENT_ID == id).Where(w => w.TERMINARZ.DATA < (DateTime?)System.DateTime.Now) ;
            viewModel.Wizyta_domowaStala = db.WIZYTA_DOMOWA.Where(w => w.PACJENT_ID == id).Where(w => w.TERMINARZ.DATA < (DateTime?)System.DateTime.Now);
            if (wiz_k != null)
            {
                viewModel.Wizyta_konsultacyjna = db.WIZYTA_KONSULTACYJNA.Where(t => t.TERMINARZ_ID == wiz_k.Value);
            }
            if (wiz_d != null)
            {
                viewModel.Wizyta_domowa = db.WIZYTA_DOMOWA.Where(t => t.TERMINARZ_ID == wiz_d.Value);
            }
            return View(viewModel);
        }
    }
}