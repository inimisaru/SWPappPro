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
    public class ZamowWizyteDomowaController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony ZamowWizyteDomowa</returns>
        public ActionResult ZamowWizyteDomowa()
        {
            return View(db.LEKARZ.ToList());
        }
        public ActionResult ZamowWizyteDomowaData(int? id)
        {
            Session["id_lek"] = id;

            //Stworzenie nowego obiektu modelu KalendarzModel
            var viewModel = new KalendarzModel();

            //Załadowanie do Terminarza tabeli Terminarz
            viewModel.Terminarz = db.TERMINARZ
                .Include(i => i.WIZYTA_KONSULTACYJNA)
                .OrderBy(i => i.DATA).Where(w => w.LEKARZ_ID == id).Where(w => w.DATA >= (DateTime?)System.DateTime.Now);
            //Załadowanie Tabeli wizyta konsultacyjna
            viewModel.Wizyta_konsultacyjnaStala = db.WIZYTA_KONSULTACYJNA;
            viewModel.Wizyta_domowaStala = db.WIZYTA_DOMOWA;

     
            return View(viewModel);
        }
        public ActionResult ZamowWizyteDomowaFormularz(int? id)
        {
            Session["id_data"] = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ZamowWizyteDomowaFormularz([Bind(Include = "WIZYTA_DOMOWA_ID,PACJENT_ID,LEKARZ_ID,TERMINARZ_ID,ULICA,KOD_POCZTOWY,NR_DOMU,MIEJSCOWOSC")] WIZYTA_DOMOWA wIZYTA_DOMOWA)
        {
            if (ModelState.IsValid)
            {
                wIZYTA_DOMOWA.LEKARZ_ID = (int?)Session["id_lek"];
                wIZYTA_DOMOWA.PACJENT_ID = (int?)Session["id"];
                wIZYTA_DOMOWA.TERMINARZ_ID = (int?)Session["id_data"];
                db.WIZYTA_DOMOWA.Add(wIZYTA_DOMOWA);
                db.SaveChanges();
                Session["id_lek"] = "";
                Session["id_data"] = "";
                return RedirectToAction("ZamowWizyteDomowa");
            }

            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", wIZYTA_DOMOWA.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", wIZYTA_DOMOWA.PACJENT_ID);
            ViewBag.TERMINARZ_ID = new SelectList(db.TERMINARZ, "TERMINARZ_ID", "TERMINARZ_ID", wIZYTA_DOMOWA.TERMINARZ_ID);
            return View(wIZYTA_DOMOWA);
        }


        /// <summary>
        /// Metoda formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony ZamowWizyteDomowaWynik</returns>
        [HttpPost]
        public ActionResult ZamowWizyteDomowaZatwierdz()
        {
            return View("ZamowWizyteDomowaWynik");
        }
    }
}