﻿using System;
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
        /// <summary>
        /// Metoda wywoływana po wybraniu wizyty domowej do przeplanowania.
        /// </summary>
        /// <param name="id">Identyfikator daty wizyty do przeplanowania</param>
        /// <returns>Zwraca widok PrzeplanujWizyteDom z listą dostępnych terminów</returns>
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
                .OrderBy(i => i.DATA).Where(w => w.LEKARZ_ID == id_lek).Where(w => w.DATA >= (DateTime?)System.DateTime.Now);
            //Załadowanie Tabeli wizyta konsultacyjna
            viewModel.Wizyta_konsultacyjnaStala = db.WIZYTA_KONSULTACYJNA;
            viewModel.Wizyta_domowaStala = db.WIZYTA_DOMOWA;

            return View(viewModel);
        }
        /// <summary>
        /// Metoda wywoływana po wybraniu wizyty konsultacyjnej do przeplanowania.
        /// </summary>
        /// <param name="id">Identyfikator daty wizyty do przeplanowania</param>
        /// <returns>Zwraca widok PrzeplanujWizyteDom z listą dostępnych terminów</returns>
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
                .OrderBy(i => i.DATA).Where(w => w.LEKARZ_ID == id_lek).Where(w => w.DATA >= (DateTime?)System.DateTime.Now);
            //Załadowanie Tabeli wizyta konsultacyjna
            viewModel.Wizyta_konsultacyjnaStala = db.WIZYTA_KONSULTACYJNA;
            viewModel.Wizyta_domowaStala = db.WIZYTA_DOMOWA;

            return View(viewModel);
        }
        /// <summary>
        /// Metoda zapisująca do bazy danych wprowadzone zmiany w wizycie domowej
        /// </summary>
        /// <param name="id">Identyfikator nowego terminu</param>
        /// <returns>Zwraca widok PrzeplanujWizyte zawierający listę wszystkich wizyt</returns>
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
            return View(wIZYTA_DOMOWA);
        }
        /// <summary>
        /// Metoda zapisująca do bazy danych wprowadzone zmiany w wizycie konsultacyjnej
        /// </summary>
        /// <param name="id">Identyfikator nowego terminu</param>
        /// <returns>Zwraca widok PrzeplanujWizyte zawierający listę wszystkich wizyt</returns>
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
    }
}