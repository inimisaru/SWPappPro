using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class PacjentController : Controller
    {
        // GET: Pacjent
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Wizyty()
        {
            return View();
        }
        public ActionResult Konsultacje()
        {
            return View();
        }
        public ActionResult Lekarze()
        {
            return View();
        }
        public ActionResult Profil()
        {
            return View();
        }
        public ActionResult AktualizujProfilPacjenta()
        {
            return RedirectToAction("AktualizujProfilPacjenta","AktualizujProfilPacjenta");
        }
        public ActionResult PodejrzyjSwojaKartePacjenta()
        {
            return RedirectToAction("PodejrzyjSwojaKartePacjenta", "PodejrzyjSwojaKartePacjenta");
        }
        public ActionResult OdczytajPowiadomienie()
        {
            return RedirectToAction("OdczytajPowiadomienie", "OdczytajPowiadomienie");
        }
        public ActionResult ZamowWizyteDomowa()
        {
            return RedirectToAction("ZamowWizyteDomowa", "ZamowWizyteDomowa");
        }
        public ActionResult ZamowWizyteKonsultacyjna()
        {
            return RedirectToAction("ZamowWizyteKonsultacyjna", "ZamowWizyteKonsultacyjna");
        }
        public ActionResult PrzeplanujWizyte()
        {
            return RedirectToAction("PrzeplanujWizyte", "PrzeplanujWizyte");
        }
        public ActionResult WyswietlHistorieWizyt()
        {
            return RedirectToAction("WyswietlHistorieWizyt", "WyswietlHistorieWizyt");
        }
        public ActionResult WystawOpinie()
        {
            return RedirectToAction("WystawOpinie", "WystawOpinie");
        }
    }
}