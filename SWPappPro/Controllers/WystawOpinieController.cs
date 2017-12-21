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
    /// Autor: Dawid Stefański
    /// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
    /// </summary>
    public class WystawOpinieController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();
        int? id_l;
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony WystawOpinie</returns>
        public ActionResult WystawOpinie()
        {
            return View(db.LEKARZ.ToList());
            //return View();
        }
        /// <summary>
        /// Metoda formularza służąca do zwracania widoku strony podanej w argumencie.
        /// </summary>
        /// <returns>widok strony WystawOpinieWynik</returns>

        public ActionResult WystawOpinieFormularz(int? id)
        {
            Session["id_lek_opinia"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WystawOpinieFormularz([Bind(Include = "OPINIA_ID,NUMER_OPINII,TRESC,OCENA,LEKARZ_ID,PACJENT_ID")] OPINIA oPINIA)
        {
            if (ModelState.IsValid)
            {
                oPINIA.LEKARZ_ID = (int?)Session["id_lek_opinia"];
                oPINIA.PACJENT_ID = (int?)Session["id"];
                db.OPINIA.Add(oPINIA);
                db.SaveChanges();
                return View("WystawOpinieWynik");
            }

            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", oPINIA.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", oPINIA.PACJENT_ID);
            return View(oPINIA);
        }




    }
}