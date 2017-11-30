using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    /// <summary>
    /// Controller dla lekarza, do nawigowania pomiedzy menu dostępnymi dla lekarza
    /// </summary>
    public class LekarzController : Controller
    {
        /// <summary>
        /// Metoda zwraca widok strony z Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View("Index");
        }
        /// <summary>
        /// Metoda zwaraca widok strony z menu Wizyty
        /// </summary>
        /// <returns></returns>
        public ActionResult Wizyty()
        {
            return View();
        }
        /// <summary>
        /// Metoda zwaraca widok strony z menu Konsultacje
        /// </summary>
        /// <returns></returns>
        public ActionResult Konsultacje()
        {
            return View();
        }
        /// <summary>
        /// Metoda zwaraca widok strony z menu Pacjenci
        /// </summary>
        /// <returns></returns>
        public ActionResult Pacjenci()
        {
            return View();
        }
        /// <summary>
        /// Metoda zwaraca widok strony z menu Profil
        /// </summary>
        /// <returns></returns>
        public ActionResult Profil()
        {
            return View();
        }
        /// <summary>
        /// Metoda przekierowujaca do metody kontrolera WyswietlKartePacjenta wyswietlajaca strone WyswietlKartePacjenta
        /// </summary>
        /// <returns></returns>
        public ActionResult WyswietlKartePacjenta()
        {
            return RedirectToAction("WyswietlKartePacjenta","WyswietlKartePacjenta");
        }
        /// <summary>
        /// Metoda przekierowujaca do metody kontrolera PodepnijWynikiDoKartyPacjenta wyswietlajaca strone PodepnijWynikiDoKartyPacjenta
        /// </summary>
        /// <returns></returns>
        public ActionResult PodepnijWynikiDoKartyPacjenta()
        {
            return RedirectToAction("PodepnijWynikiDoKartyPacjenta", "PodepnijWynikiDoKartyPacjenta");
        }
        /// <summary>
        /// Metoda przekierowujaca do metody kontrolera AktualizujSwojProfil wyswietlajaca strone AktualizujSwojProfil
        /// </summary>
        /// <returns></returns>
        public ActionResult AktualizujSwojProfil()
        {
            return RedirectToAction("AktualizujSwojProfil", "AktualizujSwojProfil");
        }
        /// <summary>
        /// Metoda przekierowujaca do metody kontrolera WyswietlOpinie wyswietlajaca strone WyswietlOpinie
        /// </summary>
        /// <returns></returns>
        public ActionResult WyswietlOpinie()
        {
            return RedirectToAction("WyswietlOpinie", "WyswietlOpinie");
        }
        /// <summary>
        /// Metoda przekierowujaca do metody kontrolera UmowWizyte wyswietlajaca strone UmowWizyte
        /// </summary>
        /// <returns></returns>
        public ActionResult UmowWizyte()
        {
            return RedirectToAction("UmowWizyte", "UmowWizyte");
        }
        /// <summary>
        /// Metoda przekierowujaca do metody kontrolera WyswietlKalendarz wyswietlajaca strone WyswietlKalendarz
        /// </summary>
        /// <returns></returns>
        public ActionResult WyswietlKalendarz()
        {
            return RedirectToAction("WyswietlKalendarz", "WyswietlKalendarz");
        }
        /// <summary>
        /// Metoda przekierowujaca do metody kontrolera DodajWolnyTerminWizyty wyswietlajaca strone DodajWolnyTerminWizyty
        /// </summary>
        /// <returns></returns>
        public ActionResult DodajWolnyTerminWizyty()
        {
            return RedirectToAction("DodajWolnyTerminWizyty", "DodajWolnyTerminWizyty");
        }
        /// <summary>
        /// Metoda przekierowujaca do metody kontrolera PowiadomOStatusieWizyty wyswietlajaca strone PowiadomOStatusieWizyty
        /// </summary>
        /// <returns></returns>
        public ActionResult PowiadomOStatusieWizyty()
        {
            return RedirectToAction("PowiadomOStatusieWizyty", "PowiadomOStatusieWizyty");
        }
        /// <summary>
        /// Metoda przekierowujaca do metody kontrolera OdpowiedzNaWezwanieDoWizytyDomowej wyswietlajaca strone OdpowiedzNaWezwanieDoWizytyDomowej
        /// </summary>
        /// <returns></returns>
        public ActionResult OdpowiedzNaWezwanieDoWizytyDomowej()
        {
            return RedirectToAction("OdpowiedzNaWezwanieDoWizytyDomowej", "OdpowiedzNaWezwanieDoWizytyDomowej");
        }
    }
}