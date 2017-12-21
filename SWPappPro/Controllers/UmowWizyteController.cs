using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SWPappPro.Models;

namespace SWPappPro.Controllers
{/// <summary>
/// Autor: Bartłomiej Balak
/// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
/// </summary>
    public class UmowWizyteController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();
        // GET: UmowWizyte
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony .
        /// </summary>
        /// <returns>widok strony UmowWizyte</returns>
        public ActionResult UmowWizyte()
        {
            return View();
        }
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony UmowWizyteKon</returns>
        public ActionResult UmowWizyteKon(int? wybor)
        {
            int id = (int)Session["id"];

            //Stworzenie nowego obiektu modelu KalendarzModel
            var viewModel = new KalendarzModel();

            //Załadowanie do Terminarza tabeli Terminarz
            viewModel.Terminarz = db.TERMINARZ
                .Include(i => i.WIZYTA_KONSULTACYJNA)
                .OrderBy(i => i.DATA).Where(w => w.LEKARZ_ID == id);
            //Załadowanie Tabeli wizyta konsultacyjna
            viewModel.Wizyta_konsultacyjnaStala = db.WIZYTA_KONSULTACYJNA;
            viewModel.Wizyta_domowaStala = db.WIZYTA_DOMOWA;

            if (wybor != null)
            {
                viewModel.Wizyta_konsultacyjna = db.WIZYTA_KONSULTACYJNA.Where(t => t.TERMINARZ_ID == wybor.Value);
            }

            return View(viewModel);
        }
        public ActionResult UmowWizyteKonWybierzGabinet(int? terminarz_id)
        {
            Session["terminarz_id"] = terminarz_id;
            var gABINET = db.GABINET.Include(g => g.LEKARZ);
            return View(gABINET.ToList());
        }
        public ActionResult UmowWizyteKonWybierzPacjenta(int? gabinet_id)
        {
            Session["gabinet_id"] = gabinet_id;
            return View(db.PACJENT.ToList());
        }
        public ActionResult UmowWizyteKonFormularz(int? pacjent_id)
        {
            Session["pacjent_id"] = pacjent_id;
            return View();
        }

       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UmowWizyteKonFormularz([Bind(Include = "WIZYTA_KONSULTACYJNA_ID,PACJENT_ID,GABINET_ID,LEKARZ_ID,TERMINARZ_ID,CEL,DODATKOWE_UWAGI")] WIZYTA_KONSULTACYJNA wIZYTA_KONSULTACYJNA)
        {
            if (ModelState.IsValid)
            {
                wIZYTA_KONSULTACYJNA.PACJENT_ID = (int?)Session["pacjent_id"];
                wIZYTA_KONSULTACYJNA.GABINET_ID = (int?)Session["gabinet_id"];
                wIZYTA_KONSULTACYJNA.TERMINARZ_ID = (int?)Session["terminarz_id"];
                wIZYTA_KONSULTACYJNA.LEKARZ_ID = (int?)Session["id"];
                db.WIZYTA_KONSULTACYJNA.Add(wIZYTA_KONSULTACYJNA);
                db.SaveChanges();
                Session["gabinet_id"] = "";
                Session["terminarz_id"] = "";
                Session["pacjent_id"] = "";
                return View("UmowWizyteWynik");
            }

            ViewBag.GABINET_ID = new SelectList(db.GABINET, "GABINET_ID", "NR", wIZYTA_KONSULTACYJNA.GABINET_ID);
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", wIZYTA_KONSULTACYJNA.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", wIZYTA_KONSULTACYJNA.PACJENT_ID);
            ViewBag.TERMINARZ_ID = new SelectList(db.TERMINARZ, "TERMINARZ_ID", "TERMINARZ_ID", wIZYTA_KONSULTACYJNA.TERMINARZ_ID);
            return View(wIZYTA_KONSULTACYJNA);
        }


        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony UmowWizyteDom</returns>
        public ActionResult UmowWizyteDom(int? wybor)
        {
            int id = (int)Session["id"];

            //Stworzenie nowego obiektu modelu KalendarzModel
            var viewModel = new KalendarzModel();

            //Załadowanie do Terminarza tabeli Terminarz
            viewModel.Terminarz = db.TERMINARZ
                .Include(i => i.WIZYTA_KONSULTACYJNA)
                .OrderBy(i => i.DATA).Where(w => w.LEKARZ_ID == id);
            //Załadowanie Tabeli wizyta konsultacyjna
            viewModel.Wizyta_konsultacyjnaStala = db.WIZYTA_KONSULTACYJNA;
            viewModel.Wizyta_domowaStala = db.WIZYTA_DOMOWA;

            if (wybor != null)
            {
                viewModel.Wizyta_konsultacyjna = db.WIZYTA_KONSULTACYJNA.Where(t => t.TERMINARZ_ID == wybor.Value);
            }

            return View(viewModel);
        }
        public ActionResult UmowWizyteDomWybierzPacjenta(int? terminarz_id)
        {
            Session["terminarz_id"] = terminarz_id;
            return View(db.PACJENT.ToList());
        }
        public ActionResult UmowWizyteDomFormularz(int? pacjent_id)
        {
            Session["pacjent_id"] = pacjent_id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UmowWizyteDomFormularz([Bind(Include = "WIZYTA_DOMOWA_ID,PACJENT_ID,LEKARZ_ID,TERMINARZ_ID,ULICA,KOD_POCZTOWY,NR_DOMU,MIEJSCOWOSC")] WIZYTA_DOMOWA wIZYTA_DOMOWA)
        {
            if (ModelState.IsValid)
            {
                wIZYTA_DOMOWA.LEKARZ_ID = (int?)Session["id"];
                wIZYTA_DOMOWA.PACJENT_ID = (int?)Session["pacjent_id"];
                wIZYTA_DOMOWA.TERMINARZ_ID = (int?)Session["terminarz_id"];
                db.WIZYTA_DOMOWA.Add(wIZYTA_DOMOWA);
                db.SaveChanges();
                Session["terminarz_id"] = "";
                Session["pacjent_id"] = "";
                return View("UmowWizyteWynik");
            }

            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", wIZYTA_DOMOWA.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", wIZYTA_DOMOWA.PACJENT_ID);
            ViewBag.TERMINARZ_ID = new SelectList(db.TERMINARZ, "TERMINARZ_ID", "TERMINARZ_ID", wIZYTA_DOMOWA.TERMINARZ_ID);
            return View(wIZYTA_DOMOWA);
        }


        /// <summary>
        /// Metoda formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony UmowWizyteWynik</returns>
        [HttpPost]
        public ActionResult UmowWizyteKonZatwierdz()
        {
            return View("UmowWizyteWynik");
        }
        /// <summary>
        /// Funkcja formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony UmowWizyteWynik</returns>
        [HttpPost]
        public ActionResult UmowWizyteDomZatwierdz()
        {
            return View("UmowWizyteWynik");
        }
    }
}