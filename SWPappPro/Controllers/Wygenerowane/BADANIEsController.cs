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
    public class BADANIEsController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();

        // GET: BADANIEs
        public ActionResult Index()
        {
            var bADANIE = db.BADANIE.Include(b => b.KARTA_PACJENTA).Include(b => b.LEKARZ);
            return View(bADANIE.ToList());
        }

        // GET: BADANIEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BADANIE bADANIE = db.BADANIE.Find(id);
            if (bADANIE == null)
            {
                return HttpNotFound();
            }
            return View(bADANIE);
        }

        // GET: BADANIEs/Create
        public ActionResult Create()
        {
            ViewBag.KARTA_PACJENTA_ID = new SelectList(db.KARTA_PACJENTA, "KARTA_PACJENTA_ID", "NUMER_KARTY");
            ViewBag.LEKARZ_ZLECAJACY = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE");
            return View();
        }

        // POST: BADANIEs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DATA_BADANIA,RODZAJ,WYNIK,BADANIE_ID,KARTA_PACJENTA_ID,LEKARZ_ZLECAJACY")] BADANIE bADANIE)
        {
            if (ModelState.IsValid)
            {
                db.BADANIE.Add(bADANIE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KARTA_PACJENTA_ID = new SelectList(db.KARTA_PACJENTA, "KARTA_PACJENTA_ID", "NUMER_KARTY", bADANIE.KARTA_PACJENTA_ID);
            ViewBag.LEKARZ_ZLECAJACY = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", bADANIE.LEKARZ_ZLECAJACY);
            return View(bADANIE);
        }

        // GET: BADANIEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BADANIE bADANIE = db.BADANIE.Find(id);
            if (bADANIE == null)
            {
                return HttpNotFound();
            }
            ViewBag.KARTA_PACJENTA_ID = new SelectList(db.KARTA_PACJENTA, "KARTA_PACJENTA_ID", "NUMER_KARTY", bADANIE.KARTA_PACJENTA_ID);
            ViewBag.LEKARZ_ZLECAJACY = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", bADANIE.LEKARZ_ZLECAJACY);
            return View(bADANIE);
        }

        // POST: BADANIEs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DATA_BADANIA,RODZAJ,WYNIK,BADANIE_ID,KARTA_PACJENTA_ID,LEKARZ_ZLECAJACY")] BADANIE bADANIE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bADANIE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KARTA_PACJENTA_ID = new SelectList(db.KARTA_PACJENTA, "KARTA_PACJENTA_ID", "NUMER_KARTY", bADANIE.KARTA_PACJENTA_ID);
            ViewBag.LEKARZ_ZLECAJACY = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", bADANIE.LEKARZ_ZLECAJACY);
            return View(bADANIE);
        }

        // GET: BADANIEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BADANIE bADANIE = db.BADANIE.Find(id);
            if (bADANIE == null)
            {
                return HttpNotFound();
            }
            return View(bADANIE);
        }

        // POST: BADANIEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BADANIE bADANIE = db.BADANIE.Find(id);
            db.BADANIE.Remove(bADANIE);
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
