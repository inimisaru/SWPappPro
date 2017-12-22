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
    public class PrzeplanujWizyteController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony PrzeplanujWizyte</returns>
        public ActionResult PrzeplanujWizyte()
        {
            int id = (int)Session["id"];

            //Stworzenie nowego obiektu modelu KalendarzModel
            var viewModel = new KalendarzModel();

            //Załadowanie do Terminarza tabeli Terminarz
            viewModel.Terminarz = db.TERMINARZ
                .Include(i => i.WIZYTA_KONSULTACYJNA)
                .OrderBy(i => i.DATA).Where(w => w.LEKARZ_ID == id).Where(w=>w.DATA>=(DateTime?)System.DateTime.Now);
            //Załadowanie Tabeli wizyta konsultacyjna
            viewModel.Wizyta_konsultacyjnaStala = db.WIZYTA_KONSULTACYJNA.Where(w=>w.PACJENT_ID==id);
            viewModel.Wizyta_domowaStala = db.WIZYTA_DOMOWA.Where(w => w.PACJENT_ID == id);


            return View(viewModel);
        }
        public ActionResult PrzeplanujWizyteDom(int? id)
        {
            
            WIZYTA_DOMOWA wIZYTA_DOMOWA = db.WIZYTA_DOMOWA.Where(w => w.TERMINARZ_ID == id).FirstOrDefault();
            Session["id_w"] = wIZYTA_DOMOWA.WIZYTA_DOMOWA_ID;

            int? id_lek = wIZYTA_DOMOWA.LEKARZ_ID;
            //Stworzenie nowego obiektu modelu KalendarzModel
            var viewModel = new KalendarzModel();

            //Załadowanie do Terminarza tabeli Terminarz
            viewModel.Terminarz = db.TERMINARZ
                .Include(i => i.WIZYTA_KONSULTACYJNA)
                .OrderBy(i => i.DATA).Where(w => w.LEKARZ_ID == id_lek);
            //Załadowanie Tabeli wizyta konsultacyjna
            viewModel.Wizyta_konsultacyjnaStala = db.WIZYTA_KONSULTACYJNA;
            viewModel.Wizyta_domowaStala = db.WIZYTA_DOMOWA;

            return View(viewModel);
        }
        public ActionResult PrzeplanujWizyteKon(int? id)
        {
            WIZYTA_KONSULTACYJNA wIZYTA_KONSULTACYJNA = db.WIZYTA_KONSULTACYJNA.Where(w => w.TERMINARZ_ID == id).FirstOrDefault();
            Session["id_w"] = wIZYTA_KONSULTACYJNA.WIZYTA_KONSULTACYJNA_ID;

            int? id_lek = wIZYTA_KONSULTACYJNA.LEKARZ_ID;
            //Stworzenie nowego obiektu modelu KalendarzModel
            var viewModel = new KalendarzModel();

            //Załadowanie do Terminarza tabeli Terminarz
            viewModel.Terminarz = db.TERMINARZ
                .Include(i => i.WIZYTA_KONSULTACYJNA)
                .OrderBy(i => i.DATA).Where(w => w.LEKARZ_ID == id_lek);
            //Załadowanie Tabeli wizyta konsultacyjna
            viewModel.Wizyta_konsultacyjnaStala = db.WIZYTA_KONSULTACYJNA;
            viewModel.Wizyta_domowaStala = db.WIZYTA_DOMOWA;

            return View(viewModel);
        }
        public ActionResult PrzeplanujWizyteDomFormularz(int? id)
        {
            int? id_w = (int?)Session["id_w"];

            WIZYTA_DOMOWA wIZYTA_DOMOWA = db.WIZYTA_DOMOWA.Find(id_w);

            wIZYTA_DOMOWA.TERMINARZ_ID = id;

            if (ModelState.IsValid)
            {
                db.Entry(wIZYTA_DOMOWA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PrzeplanujWizyte");
            }
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", wIZYTA_DOMOWA.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", wIZYTA_DOMOWA.PACJENT_ID);
            ViewBag.TERMINARZ_ID = new SelectList(db.TERMINARZ, "TERMINARZ_ID", "TERMINARZ_ID", wIZYTA_DOMOWA.TERMINARZ_ID);
            return View(wIZYTA_DOMOWA);
        }
        public ActionResult PrzeplanujWizyteKonFormularz(int? id)
        {
            int? id_w = (int?)Session["id_w"];

            WIZYTA_KONSULTACYJNA wIZYTA_KONSULTACYJNA = db.WIZYTA_KONSULTACYJNA.Find(id_w);

            wIZYTA_KONSULTACYJNA.TERMINARZ_ID = id;

            if (ModelState.IsValid)
            {
                db.Entry(wIZYTA_KONSULTACYJNA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PrzeplanujWizyte");
            }
            return View(wIZYTA_KONSULTACYJNA);
        }



        /// <summary>
        /// Metoda formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony PrzeplanujWizyteFormularz</returns>
        [HttpPost]
        public ActionResult PrzeplanujWizyteWybor()
        {
            return View("PrzeplanujWizyteFormularz");
        }
        /// <summary>
        /// Metoda formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony PrzeplanujWizyteWynik</returns>
        [HttpPost]
        public ActionResult PrzeplanujWizyteZatwierdz()
        {
            return View("PrzeplanujWizyteWynik");
        }
    }
}