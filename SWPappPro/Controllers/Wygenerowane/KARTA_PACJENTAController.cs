using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SWPappPro.Models;

namespace SWPappPro.Controllers.Wygenerowane
{
    public class KARTA_PACJENTAController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();

        // GET: KARTA_PACJENTA
        public ActionResult Index()
        {
            var kARTA_PACJENTA = db.KARTA_PACJENTA.Include(k => k.LEKARZ).Include(k => k.PACJENT);
            return View(kARTA_PACJENTA.ToList());
        }

        // GET: KARTA_PACJENTA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KARTA_PACJENTA kARTA_PACJENTA = db.KARTA_PACJENTA.Find(id);
            if (kARTA_PACJENTA == null)
            {
                return HttpNotFound();
            }
            return View(kARTA_PACJENTA);
        }

        // GET: KARTA_PACJENTA/Create
        public ActionResult Create()
        {
            ViewBag.PROWADZACY = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE");
            ViewBag.WLASCICIEL = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE");
            return View();
        }

        // POST: KARTA_PACJENTA/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KARTA_PACJENTA_ID,NUMER_KARTY,DATA_ZALOZENIA,WLASCICIEL,PROWADZACY")] KARTA_PACJENTA kARTA_PACJENTA)
        {
            if (ModelState.IsValid)
            {
                db.KARTA_PACJENTA.Add(kARTA_PACJENTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PROWADZACY = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", kARTA_PACJENTA.PROWADZACY);
            ViewBag.WLASCICIEL = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", kARTA_PACJENTA.WLASCICIEL);
            return View(kARTA_PACJENTA);
        }

        // GET: KARTA_PACJENTA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KARTA_PACJENTA kARTA_PACJENTA = db.KARTA_PACJENTA.Find(id);
            if (kARTA_PACJENTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.PROWADZACY = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", kARTA_PACJENTA.PROWADZACY);
            ViewBag.WLASCICIEL = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", kARTA_PACJENTA.WLASCICIEL);
            return View(kARTA_PACJENTA);
        }

        // POST: KARTA_PACJENTA/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KARTA_PACJENTA_ID,NUMER_KARTY,DATA_ZALOZENIA,WLASCICIEL,PROWADZACY")] KARTA_PACJENTA kARTA_PACJENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kARTA_PACJENTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PROWADZACY = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", kARTA_PACJENTA.PROWADZACY);
            ViewBag.WLASCICIEL = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", kARTA_PACJENTA.WLASCICIEL);
            return View(kARTA_PACJENTA);
        }

        // GET: KARTA_PACJENTA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KARTA_PACJENTA kARTA_PACJENTA = db.KARTA_PACJENTA.Find(id);
            if (kARTA_PACJENTA == null)
            {
                return HttpNotFound();
            }
            return View(kARTA_PACJENTA);
        }

        // POST: KARTA_PACJENTA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KARTA_PACJENTA kARTA_PACJENTA = db.KARTA_PACJENTA.Find(id);
            db.KARTA_PACJENTA.Remove(kARTA_PACJENTA);
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
