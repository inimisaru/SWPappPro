using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class OdpowiedzNaWezwanieDoWizytyDomowejController : Controller
    {
        /// <summary>
        /// Metoda zwraca strone z lista wizyt domowych pobrana na podstawie identyfikatora lekarza.
        /// Identyfikator lekarza zapisany jest w zmiennych Sesji
        /// Wewnatrz metody zostanie wywolana metoda obiektu Models realizujaca dostęp do bazy danych.
        /// </summary>
        /// <returns>strona OdpowiedzNaWezwanieDoWizytyDomowej</returns>
        public ActionResult OdpowiedzNaWezwanieDoWizytyDomowej()
        {
            return View();
        }
        /// <summary>
        /// Po wybraniu WizytyDomowej i wpisaniu odpowiedzi zostanie wywołana
        /// metoda obiektu Models realizujaca zapisanie odpowiedzi do bazy danych.
        /// Zwrócona zostanie strona z potwierdzeniem wykonania akcji.
        /// </summary>
        /// <returns>strona OdpowiedzNaWezwanieDoWizytyDomowejWynik</returns>
        [HttpPost]
        public ActionResult OdpowiedzNaWezwanieDoWizytyDomowejZatwierdz()
        {
            return View("OdpowiedzNaWezwanieDoWizytyDomowejWynik");
        }

    }
}