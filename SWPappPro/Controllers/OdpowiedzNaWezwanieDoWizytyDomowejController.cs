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
    /// <summary>
    /// Autor: Bartłomiej Balak
    /// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
    /// </summary>
    public class OdpowiedzNaWezwanieDoWizytyDomowejController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();
        /// <summary>
        /// Metoda zwraca strone z lista wizyt domowych pobrana na podstawie identyfikatora lekarza.
        /// Identyfikator lekarza zapisany jest w zmiennych Sesji
        /// Wewnatrz metody zostanie wywolana metoda obiektu Models realizujaca dostęp do bazy danych.
        /// </summary>
        /// <returns>strona OdpowiedzNaWezwanieDoWizytyDomowej</returns>
        public ActionResult OdpowiedzNaWezwanieDoWizytyDomowej()
        {
            int id = (int)Session["id"];
            var wIZYTA_DOMOWA = db.WIZYTA_DOMOWA.Where(w => w.LEKARZ_ID == id).Include(w => w.LEKARZ).Include(w => w.PACJENT).Include(w => w.TERMINARZ).Where(w => w.TERMINARZ.DATA >= (DateTime?)System.DateTime.Now);
            return View(wIZYTA_DOMOWA.ToList());
        }
        /// <summary>
        /// Po wybraniu WizytyDomowej i wpisaniu odpowiedzi zostanie wywołana
        /// metoda obiektu Models realizujaca zapisanie odpowiedzi do bazy danych.
        /// Zwrócona zostanie strona z potwierdzeniem wykonania akcji.
        /// </summary>
        /// <returns>strona OdpowiedzNaWezwanieDoWizytyDomowejWynik</returns>
        /// 
        public ActionResult OdpowiedzNaWezwanieDoWizytyDomowejFormularz(int? id_p,int? id_w)
        {
            Session["Pow_id_p"] = id_p;
            Session["Pow_id_w"] = id_w;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OdpowiedzNaWezwanieDoWizytyDomowejFormularz([Bind(Include = "POWIADOMIENIE_ID,NUMER_POWIADOMIENIA,TRESC,PACJENT_ID,LEKARZ_ID,STATUS")] POWIADOMIENIE pOWIADOMIENIE)
        {
            if (ModelState.IsValid)
            {
                pOWIADOMIENIE.NUMER_POWIADOMIENIA = (int?)Session["Pow_id_w"];
                pOWIADOMIENIE.LEKARZ_ID = (int?)Session["id"];
                pOWIADOMIENIE.PACJENT_ID = (int?)Session["Pow_id_p"];
                pOWIADOMIENIE.STATUS = "D";
                pOWIADOMIENIE.TRESC = "Wizyta domowa nr: " + Session["Pow_id_w"].ToString() + " " + pOWIADOMIENIE.TRESC;
                db.POWIADOMIENIE.Add(pOWIADOMIENIE);
                db.SaveChanges();
                Session["Pow_id_p"] = "";
                Session["Pow_id_w"] = "";
                return View("OdpowiedzNaWezwanieDoWizytyDomowejWynik");
            }

            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", pOWIADOMIENIE.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", pOWIADOMIENIE.PACJENT_ID);
            return View(pOWIADOMIENIE);
        }

        [HttpPost]
        public ActionResult OdpowiedzNaWezwanieDoWizytyDomowejZatwierdz()
        {
            return View("OdpowiedzNaWezwanieDoWizytyDomowejWynik");
        }

    }
}