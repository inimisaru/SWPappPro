using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SWPappPro.Models;

namespace SWPappPro.Views
{
    public class WIZYTA_DOMOWAController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();

        // GET: WIZYTA_DOMOWA
        public ActionResult Index()
        {
            var wIZYTA_DOMOWA = db.WIZYTA_DOMOWA.Include(w => w.LEKARZ).Include(w => w.PACJENT).Include(w => w.TERMINARZ);
            return View(wIZYTA_DOMOWA.ToList());
        }

        // GET: WIZYTA_DOMOWA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA_DOMOWA wIZYTA_DOMOWA = db.WIZYTA_DOMOWA.Find(id);
            if (wIZYTA_DOMOWA == null)
            {
                return HttpNotFound();
            }
            return View(wIZYTA_DOMOWA);
        }

        // GET: WIZYTA_DOMOWA/Create
        public ActionResult Create()
        {
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE");
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE");
            ViewBag.TERMINARZ_ID = new SelectList(db.TERMINARZ, "TERMINARZ_ID", "TERMINARZ_ID");
            return View();
        }

        // POST: WIZYTA_DOMOWA/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WIZYTA_DOMOWA_ID,PACJENT_ID,LEKARZ_ID,TERMINARZ_ID,ULICA,KOD_POCZTOWY,NR_DOMU,MIEJSCOWOSC")] WIZYTA_DOMOWA wIZYTA_DOMOWA)
        {
            if (ModelState.IsValid)
            {
                db.WIZYTA_DOMOWA.Add(wIZYTA_DOMOWA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", wIZYTA_DOMOWA.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", wIZYTA_DOMOWA.PACJENT_ID);
            ViewBag.TERMINARZ_ID = new SelectList(db.TERMINARZ, "TERMINARZ_ID", "TERMINARZ_ID", wIZYTA_DOMOWA.TERMINARZ_ID);
            return View(wIZYTA_DOMOWA);
        }

        // GET: WIZYTA_DOMOWA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA_DOMOWA wIZYTA_DOMOWA = db.WIZYTA_DOMOWA.Find(id);
            if (wIZYTA_DOMOWA == null)
            {
                return HttpNotFound();
            }
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", wIZYTA_DOMOWA.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", wIZYTA_DOMOWA.PACJENT_ID);
            ViewBag.TERMINARZ_ID = new SelectList(db.TERMINARZ, "TERMINARZ_ID", "TERMINARZ_ID", wIZYTA_DOMOWA.TERMINARZ_ID);
            return View(wIZYTA_DOMOWA);
        }

        // POST: WIZYTA_DOMOWA/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WIZYTA_DOMOWA_ID,PACJENT_ID,LEKARZ_ID,TERMINARZ_ID,ULICA,KOD_POCZTOWY,NR_DOMU,MIEJSCOWOSC")] WIZYTA_DOMOWA wIZYTA_DOMOWA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wIZYTA_DOMOWA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", wIZYTA_DOMOWA.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", wIZYTA_DOMOWA.PACJENT_ID);
            ViewBag.TERMINARZ_ID = new SelectList(db.TERMINARZ, "TERMINARZ_ID", "TERMINARZ_ID", wIZYTA_DOMOWA.TERMINARZ_ID);
            return View(wIZYTA_DOMOWA);
        }

        // GET: WIZYTA_DOMOWA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA_DOMOWA wIZYTA_DOMOWA = db.WIZYTA_DOMOWA.Find(id);
            if (wIZYTA_DOMOWA == null)
            {
                return HttpNotFound();
            }
            return View(wIZYTA_DOMOWA);
        }

        // POST: WIZYTA_DOMOWA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WIZYTA_DOMOWA wIZYTA_DOMOWA = db.WIZYTA_DOMOWA.Find(id);
            db.WIZYTA_DOMOWA.Remove(wIZYTA_DOMOWA);
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
