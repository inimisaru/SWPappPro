using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    /// <summary>
    /// Autor: Bartosz Burak
    /// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
    /// </summary>
    public class OdczytajPowiadomienieController : Controller
    {
        /// <summary>
        /// Metoda zwraca strone z lista powiadomien pobrana z bazy danych.
        /// Wewnatrz metody zostanie wywolana metoda obiektu Models realizujaca dostęp do bazy danych.
        /// Lista zostanie pobrana na podstawie identyfikatora pacjenta zapisanej w zmiennych sesji.
        /// </summary>
        /// <returns>strona OdczytajPowiadomienie</returns>
        public ActionResult OdczytajPowiadomienie()
        {
            return View();
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