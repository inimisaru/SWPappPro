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
    public class AktualizujSwojProfilController : Controller
    {
        private SWPappDBEntities db = new SWPappDBEntities();
        // GET: AktualizujSwojProfil
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AktualizujSwojProfil()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AktualizujSwojProfilZatwierdz([Bind(Include = "LEKARZ_ID,SPECJALIZACJA,NR_LICENCJI,HASLO")] LEKARZ lEKARZ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lEKARZ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lEKARZ);
        }

    }
}