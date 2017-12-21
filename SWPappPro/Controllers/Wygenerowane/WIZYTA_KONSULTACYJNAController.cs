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
    public class WIZYTA_KONSULTACYJNAController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();

        // GET: WIZYTA_KONSULTACYJNA
        public ActionResult Index()
        {
            var wIZYTA_KONSULTACYJNA = db.WIZYTA_KONSULTACYJNA.Include(w => w.GABINET).Include(w => w.LEKARZ).Include(w => w.PACJENT).Include(w => w.TERMINARZ);
            return View(wIZYTA_KONSULTACYJNA.ToList());
        }

        // GET: WIZYTA_KONSULTACYJNA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA_KONSULTACYJNA wIZYTA_KONSULTACYJNA = db.WIZYTA_KONSULTACYJNA.Find(id);
            if (wIZYTA_KONSULTACYJNA == null)
            {
                return HttpNotFound();
            }
            return View(wIZYTA_KONSULTACYJNA);
        }

        // GET: WIZYTA_KONSULTACYJNA/Create
        public ActionResult Create()
        {
            ViewBag.GABINET_ID = new SelectList(db.GABINET, "GABINET_ID", "NR");
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE");
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE");
            ViewBag.TERMINARZ_ID = new SelectList(db.TERMINARZ, "TERMINARZ_ID", "TERMINARZ_ID");
            return View();
        }

        // POST: WIZYTA_KONSULTACYJNA/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WIZYTA_KONSULTACYJNA_ID,PACJENT_ID,GABINET_ID,LEKARZ_ID,TERMINARZ_ID,CEL,DODATKOWE_UWAGI")] WIZYTA_KONSULTACYJNA wIZYTA_KONSULTACYJNA)
        {
            if (ModelState.IsValid)
            {
                db.WIZYTA_KONSULTACYJNA.Add(wIZYTA_KONSULTACYJNA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GABINET_ID = new SelectList(db.GABINET, "GABINET_ID", "NR", wIZYTA_KONSULTACYJNA.GABINET_ID);
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", wIZYTA_KONSULTACYJNA.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", wIZYTA_KONSULTACYJNA.PACJENT_ID);
            ViewBag.TERMINARZ_ID = new SelectList(db.TERMINARZ, "TERMINARZ_ID", "TERMINARZ_ID", wIZYTA_KONSULTACYJNA.TERMINARZ_ID);
            return View(wIZYTA_KONSULTACYJNA);
        }

        // GET: WIZYTA_KONSULTACYJNA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA_KONSULTACYJNA wIZYTA_KONSULTACYJNA = db.WIZYTA_KONSULTACYJNA.Find(id);
            if (wIZYTA_KONSULTACYJNA == null)
            {
                return HttpNotFound();
            }
            ViewBag.GABINET_ID = new SelectList(db.GABINET, "GABINET_ID", "NR", wIZYTA_KONSULTACYJNA.GABINET_ID);
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", wIZYTA_KONSULTACYJNA.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", wIZYTA_KONSULTACYJNA.PACJENT_ID);
            ViewBag.TERMINARZ_ID = new SelectList(db.TERMINARZ, "TERMINARZ_ID", "TERMINARZ_ID", wIZYTA_KONSULTACYJNA.TERMINARZ_ID);
            return View(wIZYTA_KONSULTACYJNA);
        }

        // POST: WIZYTA_KONSULTACYJNA/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WIZYTA_KONSULTACYJNA_ID,PACJENT_ID,GABINET_ID,LEKARZ_ID,TERMINARZ_ID,CEL,DODATKOWE_UWAGI")] WIZYTA_KONSULTACYJNA wIZYTA_KONSULTACYJNA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wIZYTA_KONSULTACYJNA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GABINET_ID = new SelectList(db.GABINET, "GABINET_ID", "NR", wIZYTA_KONSULTACYJNA.GABINET_ID);
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", wIZYTA_KONSULTACYJNA.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", wIZYTA_KONSULTACYJNA.PACJENT_ID);
            ViewBag.TERMINARZ_ID = new SelectList(db.TERMINARZ, "TERMINARZ_ID", "TERMINARZ_ID", wIZYTA_KONSULTACYJNA.TERMINARZ_ID);
            return View(wIZYTA_KONSULTACYJNA);
        }

        // GET: WIZYTA_KONSULTACYJNA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA_KONSULTACYJNA wIZYTA_KONSULTACYJNA = db.WIZYTA_KONSULTACYJNA.Find(id);
            if (wIZYTA_KONSULTACYJNA == null)
            {
                return HttpNotFound();
            }
            return View(wIZYTA_KONSULTACYJNA);
        }

        // POST: WIZYTA_KONSULTACYJNA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WIZYTA_KONSULTACYJNA wIZYTA_KONSULTACYJNA = db.WIZYTA_KONSULTACYJNA.Find(id);
            db.WIZYTA_KONSULTACYJNA.Remove(wIZYTA_KONSULTACYJNA);
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
