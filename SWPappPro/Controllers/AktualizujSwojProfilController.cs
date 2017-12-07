using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using SWPappPro.Models;



namespace SWPappPro.Controllers
{
    /// <summary>
    /// Kontroler dla aktualizacji profilu lekarza
    /// </summary>
    public class AktualizujSwojProfilController : Controller
    {
        /// <summary>
        /// Nowy obiekt SWPappDBEntities 
        /// </summary>
        private SWPappDBEntities db = new SWPappDBEntities();
        /// <summary>
        /// Metoda wyswietlajaca widok z formualarzem
        /// W formatkach znajduja sie dane pobrane z bazy danych odpowiadajace ID pobranemu ze zmiennych sesji
        /// </summary>
        /// <returns></returns>
        public ActionResult AktualizujSwojProfil()
        {
            int id = (int) Session["id"];
            LEKARZ lEKARZ = db.LEKARZ.Find(id);
            return View(lEKARZ);
        }
        /// <summary>
        /// Metoda wywolywana po wprowadzeniu zmian
        /// </summary>
        /// <param name="lEKARZ"></param> obiekt typu LEKARZ z wprowadzonymi zmianiami
        /// <returns></returns>
        [HttpPost]
        public ActionResult AktualizujSwojProfilZatwierdz([Bind(Include = "LEKARZ_ID,IMIE,NAZWISKO,SPECJALIZACJA,PESEL,DATA_URODZENIA,NR_LICENCJI,HASLO")] LEKARZ lEKARZ)
        {
                if (ModelState.IsValid)
                {
                    //oznacz jako zmienione
                    db.Entry(lEKARZ).State = EntityState.Modified;
                    //zapisz zmiany
                    db.SaveChanges();
                    //zwrócenie widoku AktualizujSwojProfil
                    return View("AktualizujSwojProfilWynik");
                }
                return View("AktualizujSwojProfil");
        }
    }
}