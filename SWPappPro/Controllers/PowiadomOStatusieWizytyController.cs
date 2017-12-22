
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
    /// Autor: Bartłomiej Balak
    /// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
    /// </summary>
    public class PowiadomOStatusieWizytyController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony .
        /// </summary>
        /// <returns>widok strony PowiadomOStatusieWizyty</returns>
        public ActionResult PowiadomOStatusieWizyty()
        {
            int id = (int)Session["id"];
            var wIZYTA_KONSULTACYJNA = db.WIZYTA_KONSULTACYJNA.Where(w => w.LEKARZ_ID == id).Include(w => w.LEKARZ).Include(w => w.PACJENT).Include(w => w.TERMINARZ).Where(w => w.TERMINARZ.DATA >= (DateTime?)System.DateTime.Now);
            return View(wIZYTA_KONSULTACYJNA.ToList());
        }
        /// <summary>
        /// Metoda formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony PowiadomOStatusieWizytyWynik</returns>
        public ActionResult PowiadomOStatusieWizytyFormularz(int? id,int? id_p)
        {
            Session["Pow_id_w"] = id;
            Session["Pow_id_p"] = id_p;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PowiadomOStatusieWizytyFormularz([Bind(Include = "POWIADOMIENIE_ID,NUMER_POWIADOMIENIA,TRESC,PACJENT_ID,LEKARZ_ID,STATUS")] POWIADOMIENIE pOWIADOMIENIE)
        {
            if (ModelState.IsValid)
            {
                pOWIADOMIENIE.NUMER_POWIADOMIENIA = (int?)Session["Pow_id_w"];
                pOWIADOMIENIE.LEKARZ_ID = (int?)Session["id"];
                pOWIADOMIENIE.PACJENT_ID = (int?)Session["Pow_id_p"];
                pOWIADOMIENIE.STATUS = "K";
                pOWIADOMIENIE.TRESC = "Wizyta konsultacyjna nr: "+Session["Pow_id_w"].ToString()+" "+pOWIADOMIENIE.TRESC;
                db.POWIADOMIENIE.Add(pOWIADOMIENIE);
                db.SaveChanges();
                return View("PowiadomOStatusieWizytyWynik");
            }

            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", pOWIADOMIENIE.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", pOWIADOMIENIE.PACJENT_ID);
            return View(pOWIADOMIENIE);
        }

    }
}