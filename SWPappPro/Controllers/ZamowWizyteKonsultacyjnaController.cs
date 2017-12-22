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
    public class ZamowWizyteKonsultacyjnaController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony ZamowWizyteKonsultacyjna</returns>
        public ActionResult ZamowWizyteKonsultacyjna()
        {
            return View(db.LEKARZ.ToList());
        }
        public ActionResult ZamowWizyteKonsultacyjnaData(int? id)
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
        public ActionResult ZamowWizyteKonsultacyjnaGabinet(int? id)
        {
            Session["id_data"] = id;
            int idlek = (int)Session["id_lek"];
            return View(db.GABINET.Where(g => g.LEKARZ_ODPOWIEDZIALNY==idlek).ToList());
        }
        public ActionResult ZamowWizyteKonsultacyjnaFormularz(int? id)
        {
            Session["id_gab"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ZamowWizyteKonsultacyjnaFormularz([Bind(Include = "WIZYTA_KONSULTACYJNA_ID,PACJENT_ID,GABINET_ID,LEKARZ_ID,TERMINARZ_ID,CEL,DODATKOWE_UWAGI")] WIZYTA_KONSULTACYJNA wIZYTA_KONSULTACYJNA)
        {
            if (ModelState.IsValid)
            {
                wIZYTA_KONSULTACYJNA.LEKARZ_ID = (int?)Session["id_lek"];
                wIZYTA_KONSULTACYJNA.GABINET_ID = (int?)Session["id_gab"];
                wIZYTA_KONSULTACYJNA.PACJENT_ID = (int?)Session["id"];
                wIZYTA_KONSULTACYJNA.TERMINARZ_ID = (int?)Session["id_data"];
                db.WIZYTA_KONSULTACYJNA.Add(wIZYTA_KONSULTACYJNA);
                db.SaveChanges();
                Session["id_lek"] = "";
                Session["id_data"] = "";
                Session["id_gab"] = "";
                return View("ZamowWizyteKonsultacyjnaWynik");
            }

            ViewBag.GABINET_ID = new SelectList(db.GABINET, "GABINET_ID", "NR", wIZYTA_KONSULTACYJNA.GABINET_ID);
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", wIZYTA_KONSULTACYJNA.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", wIZYTA_KONSULTACYJNA.PACJENT_ID);
            ViewBag.TERMINARZ_ID = new SelectList(db.TERMINARZ, "TERMINARZ_ID", "TERMINARZ_ID", wIZYTA_KONSULTACYJNA.TERMINARZ_ID);
            return View(wIZYTA_KONSULTACYJNA);
        }


        /// <summary>
        /// Metoda formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony ZamowWizyteKonsultacyjnaWynik</returns>
        [HttpPost]
        public ActionResult ZamowWizyteKonsultacyjnaZatwierdz()
        {
            return View("ZamowWizyteKonsultacyjnaWynik");
        }
    }
}