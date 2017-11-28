using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class LekarzController : Controller
    {
        // GET: Lekarz
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
        public ActionResult Pacjenci()
        {
            return View();
        }
        public ActionResult Profil()
        {
            return View();
        }
        public ActionResult WyswietlKartePacjenta()
        {
            return RedirectToAction("WyswietlKartePacjenta","WyswietlKartePacjenta");
        }
        public ActionResult PodepnijWynikiDoKartyPacjenta()
        {
            return RedirectToAction("PodepnijWynikiDoKartyPacjenta", "PodepnijWynikiDoKartyPacjenta");
        }
        public ActionResult AktualizujSwojProfil()
        {
            return RedirectToAction("AktualizujSwojProfil", "AktualizujSwojProfil");
        }
        public ActionResult WyswietlOpinie()
        {
            return RedirectToAction("WyswietlOpinie", "WyswietlOpinie");
        }
        public ActionResult UmowWizyte()
        {
            return RedirectToAction("UmowWizyte", "UmowWizyte");
        }
        public ActionResult WyswietlKalendarz()
        {
            return RedirectToAction("WyswietlKalendarz", "WyswietlKalendarz");
        }
        public ActionResult DodajWolnyTerminWizyty()
        {
            return RedirectToAction("DodajWolnyTerminWizyty", "DodajWolnyTerminWizyty");
        }
        public ActionResult PowiadomOStatusieWizyty()
        {
            return RedirectToAction("PowiadomOStatusieWizyty", "PowiadomOStatusieWizyty");
        }
        
        public ActionResult OdpowiedzNaWezwanieDoWizytyDomowej()
        {
            return RedirectToAction("OdpowiedzNaWezwanieDoWizytyDomowej", "OdpowiedzNaWezwanieDoWizytyDomowej");
        }
    }
}