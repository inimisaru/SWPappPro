using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SWPappPro.Models;

namespace SWPappPro.Controllers
{
    public class PACJENTsController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();

        // GET: PACJENTs
        public ActionResult Index()
        {
            return View(db.PACJENT.ToList());
        }

        // GET: PACJENTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACJENT pACJENT = db.PACJENT.Find(id);
            if (pACJENT == null)
            {
                return HttpNotFound();
            }
            return View(pACJENT);
        }

        // GET: PACJENTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PACJENTs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PACJENT_ID,IMIE,NAZWISKO,PESEL,DATA_URODZENIA,MIEJSCE_URODZENIA,ULICA_ZAMIESZKANIA,MIEJSCOWOSC,KOD_POCZTOWY,ADRES_E_MAIL,NR_TELEFONU,HASLO")] PACJENT pACJENT)
        {
            if (ModelState.IsValid)
            {
                db.PACJENT.Add(pACJENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pACJENT);
        }

        // GET: PACJENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACJENT pACJENT = db.PACJENT.Find(id);
            if (pACJENT == null)
            {
                return HttpNotFound();
            }
            return View(pACJENT);
        }

        // POST: PACJENTs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PACJENT_ID,IMIE,NAZWISKO,PESEL,DATA_URODZENIA,MIEJSCE_URODZENIA,ULICA_ZAMIESZKANIA,MIEJSCOWOSC,KOD_POCZTOWY,ADRES_E_MAIL,NR_TELEFONU,HASLO")] PACJENT pACJENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pACJENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pACJENT);
        }

        // GET: PACJENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACJENT pACJENT = db.PACJENT.Find(id);
            if (pACJENT == null)
            {
                return HttpNotFound();
            }
            return View(pACJENT);
        }

        // POST: PACJENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PACJENT pACJENT = db.PACJENT.Find(id);
            db.PACJENT.Remove(pACJENT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
