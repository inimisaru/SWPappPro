using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    /// <summary>
    /// Controller dla pacjenta, do nawigowania pomiedzy menu dostępnymi dla pacjenta.
    /// </summary>
    public class PacjentController : Controller
    {
        /// <summary>
        /// Metoda zwraca widok strony z Index
        /// </summary>
        /// <returns>strona Index</returns>
        public ActionResult Index()
        {
            return View("Index");
        }
        /// <summary>
        /// Metoda zwraca widok strony z Wizyty
        /// </summary>
        /// <returns>strona Wizyty</returns>
        public ActionResult Wizyty()
        {
            return View();
        }
        /// <summary>
        /// Metoda zwraca widok strony z Konsultacje
        /// </summary>
        /// <returns>strona Konsultacje</returns>
        public ActionResult Konsultacje()
        {
            return View();
        }
        /// <summary>
        /// Metoda zwraca widok strony z Lekarze
        /// </summary>
        /// <returns>strona Lekarze</returns>
        public ActionResult Lekarze()
        {
            return View();
        }
        /// <summary>
        /// Metoda zwraca widok strony z Profil
        /// </summary>
        /// <returns>strona Profil</returns>
        public ActionResult Profil()
        {
            return View();
        }
        /// <summary>
        /// Metoda przekierowujaca do metody kontrolera AktualizujProfilPacjenta wyswietlajaca strone AktualizujProfilPacjenta
        /// </summary>
        /// <returns>strona AktualizujProfilPacjenta</returns>
        public ActionResult AktualizujProfilPacjenta()
        {
            return RedirectToAction("AktualizujProfilPacjenta","AktualizujProfilPacjenta");
        }
        /// <summary>
        /// Metoda przekierowujaca do metody kontrolera PodejrzyjSwojaKartePacjenta wyswietlajaca strone PodejrzyjSwojaKartePacjenta
        /// </summary>
        /// <returns>strona PodejrzyjSwojaKartePacjenta</returns>
        public ActionResult PodejrzyjSwojaKartePacjenta()
        {
            return RedirectToAction("PodejrzyjSwojaKartePacjenta", "PodejrzyjSwojaKartePacjenta");
        }

        /// <summary>
        /// Metoda przekierowujaca do metody kontrolera OdczytajPowiadomienie wyswietlajaca strone OdczytajPowiadomienie
        /// </summary>
        /// <returns>strona OdczytajPowiadomienie</returns>
        public ActionResult OdczytajPowiadomienie()
        {
            return RedirectToAction("OdczytajPowiadomienie", "OdczytajPowiadomienie");
        }
        /// <summary>
        /// Metoda przekierowujaca do metody kontrolera ZamowWizyteDomowa wyswietlajaca strone ZamowWizyteDomowa
        /// </summary>
        /// <returns>strona ZamowWizyteDomowa</returns>
        public ActionResult ZamowWizyteDomowa()
        {
            return RedirectToAction("ZamowWizyteDomowa", "ZamowWizyteDomowa");
        }
        /// <summary>
        /// Metoda przekierowujaca do metody kontrolera ZamowWizyteKonsultacyjna wyswietlajaca strone ZamowWizyteKonsultacyjna
        /// </summary>
        /// <returns>strona ZamowWizyteKonsultacyjna</returns>
        public ActionResult ZamowWizyteKonsultacyjna()
        {
            return RedirectToAction("ZamowWizyteKonsultacyjna", "ZamowWizyteKonsultacyjna");
        }
        /// <summary>
        /// Metoda przekierowujaca do metody kontrolera PrzeplanujWizyte wyswietlajaca strone PrzeplanujWizyte
        /// </summary>
        /// <returns>strona PrzeplanujWizyte</returns>
        public ActionResult PrzeplanujWizyte()
        {
            return RedirectToAction("PrzeplanujWizyte", "PrzeplanujWizyte");
        }
        /// <summary>
        /// Metoda przekierowujaca do metody kontrolera WyswietlHistorieWizyt wyswietlajaca strone WyswietlHistorieWizyt
        /// </summary>
        /// <returns>strona WyswietlHistorieWizyt</returns>
        public ActionResult WyswietlHistorieWizyt()
        {
            return RedirectToAction("WyswietlHistorieWizyt", "WyswietlHistorieWizyt");
        }
        /// <summary>
        /// Metoda przekierowujaca do metody kontrolera WystawOpinie wyswietlajaca strone WystawOpinie
        /// </summary>
        /// <returns>strona WystawOpinie</returns>
        public ActionResult WystawOpinie()
        {
            return RedirectToAction("WystawOpinie", "WystawOpinie");
        }
    }
}