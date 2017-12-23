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
    public class OdczytajPowiadomienieController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();
        /// <summary>
        /// Metoda zwraca strone z lista powiadomien pobrana z bazy danych.
        /// Wewnatrz metody zostanie wywolana metoda obiektu Models realizujaca dostęp do bazy danych.
        /// Lista zostanie pobrana na podstawie identyfikatora pacjenta zapisanej w zmiennych sesji.
        /// </summary>
        /// <returns>strona OdczytajPowiadomienie</returns>
        public ActionResult OdczytajPowiadomienie()
        {
            int id = (int)Session["id"];
            var pOWIADOMIENIE = db.POWIADOMIENIE.Where(p=>p.PACJENT_ID==id).Include(p => p.LEKARZ).Include(p => p.PACJENT);
            return View(pOWIADOMIENIE.ToList());
        }
        /// <summary>
        /// Metoda zwracająca widok z obiektem POWIADOMIENIE o identyfikatorze id
        /// </summary>
        /// <param name="id">Identyfikator powiadomienia</param>
        /// <returns>Widok OdczytajPowiadomienieSzczegoly z obiektem POWIADOMIENIE</returns>
        public ActionResult OdczytajPowiadomienieSzczegoly(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //wyszukaj w bazie danych obiektu POWIADoMIENIE
            POWIADOMIENIE pOWIADOMIENIE = db.POWIADOMIENIE.Find(id);
            Session["id_pow"] = id;
            if (pOWIADOMIENIE == null)
            {
                return HttpNotFound();
            }
            return View(pOWIADOMIENIE);
        }
        /// <summary>
        /// Metoda usuwająca rekord o identyfikatorze id
        /// </summary>
        /// <param name="id">identyfikator rekordu do usunięcia</param>
        /// <returns>Zwracaja widok główny OdczytajPowiadomienie</returns>
        public ActionResult OdczytajPowiadomienieUsun(int? id)
        {
            POWIADOMIENIE pOWIADOMIENIE = db.POWIADOMIENIE.Find(id);
            
            if (pOWIADOMIENIE == null)
            {
                return HttpNotFound();
            }
            db.POWIADOMIENIE.Remove(pOWIADOMIENIE);
            db.SaveChanges();
            return RedirectToAction("OdczytajPowiadomienie");
        }
        /// <summary>
        /// Metoda zwracająca widok wyświetljący szczegóły danego rekordu
        /// </summary>
        /// <param name="id">Identyfikator rekordu</param>
        /// <returns>W zależności od tego jakie jest to powiadomienie zwracany jest widok ze szczegółami Wizyty Domowej lub Konsultacyjnej</returns>
        public ActionResult OdczytajPowiadomienieSzczegolyWizyty(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POWIADOMIENIE pOWIADOMIENIE = db.POWIADOMIENIE.Find((int?)Session["id_pow"]);
            string K = "K";
            string status = pOWIADOMIENIE.STATUS;
            int result = string.Compare(K, status, true);
            Session["status"] = result;
            if (result==1)
            {
                WIZYTA_DOMOWA wIZYTA_DOMOWA = db.WIZYTA_DOMOWA.Find(id);
                return View("OdczytajPowiadomienieSzczegolyWizytyDom", wIZYTA_DOMOWA);

            }
            else
            {
                
                WIZYTA_KONSULTACYJNA wIZYTA_KONSULTACYJNA = db.WIZYTA_KONSULTACYJNA.Find(id);
                return View("OdczytajPowiadomienieSzczegolyWizytyKon", wIZYTA_KONSULTACYJNA);
            }
        }

        /// <summary>
        /// Parametrem wejsciowym bedzie wybrany z listy przez uzytkownika obiekt Powiadomienia.
        /// Zwrocona zostanie strona z wypisana trescia powiadomienia.
        /// </summary>
        /// <returns>strona OdczytajPowiadomienieWynik</returns>
        [HttpPost]
        public ActionResult OdczytajPowiadomienieZatwierdz()
        {
            return View("OdczytajPowiadomienieWynik");
        }
    }
}