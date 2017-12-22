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
{
    public class WyswietlUmowioneWizytyController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();
        // GET: WyswietlUmowioneWizyty
        public ActionResult WyswietlUmowioneWizyty(int? wiz_k, int? wiz_d)
        {
            int id = (int)Session["id"];

            //Stworzenie nowego obiektu modelu KalendarzModel
            var viewModel = new KalendarzModel();

            //Załadowanie do Terminarza tabeli Terminarz
            viewModel.Terminarz = db.TERMINARZ
                .Include(i => i.WIZYTA_KONSULTACYJNA)
                .OrderBy(i => i.DATA).Where(w => w.LEKARZ_ID == id);
            //Załadowanie Tabeli wizyta konsultacyjna
            viewModel.Wizyta_konsultacyjnaStala = db.WIZYTA_KONSULTACYJNA.Where(w=>w.LEKARZ_ID==id);
            viewModel.Wizyta_domowaStala = db.WIZYTA_DOMOWA.Where(w => w.LEKARZ_ID == id);

            if (wiz_k != null)
            {
                viewModel.Wizyta_konsultacyjna = db.WIZYTA_KONSULTACYJNA.Where(t => t.TERMINARZ_ID == wiz_k.Value);
            }
            if(wiz_d != null)
            {
                viewModel.Wizyta_domowa = db.WIZYTA_DOMOWA.Where(t => t.TERMINARZ_ID == wiz_d.Value);
            }

            return View(viewModel);
        }
    }
}