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
    public class OPINIAsController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();

        // GET: OPINIAs
        public ActionResult Index()
        {
            var oPINIA = db.OPINIA.Include(o => o.LEKARZ).Include(o => o.PACJENT);
            return View(oPINIA.ToList());
        }

        // GET: OPINIAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPINIA oPINIA = db.OPINIA.Find(id);
            if (oPINIA == null)
            {
                return HttpNotFound();
            }
            return View(oPINIA);
        }

        // GET: OPINIAs/Create
        public ActionResult Create()
        {
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE");
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE");
            return View();
        }

        // POST: OPINIAs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OPINIA_ID,NUMER_OPINII,TRESC,OCENA,LEKARZ_ID,PACJENT_ID")] OPINIA oPINIA)
        {
            if (ModelState.IsValid)
            {
                db.OPINIA.Add(oPINIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", oPINIA.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", oPINIA.PACJENT_ID);
            return View(oPINIA);
        }

        // GET: OPINIAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPINIA oPINIA = db.OPINIA.Find(id);
            if (oPINIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", oPINIA.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", oPINIA.PACJENT_ID);
            return View(oPINIA);
        }

        // POST: OPINIAs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OPINIA_ID,NUMER_OPINII,TRESC,OCENA,LEKARZ_ID,PACJENT_ID")] OPINIA oPINIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oPINIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", oPINIA.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", oPINIA.PACJENT_ID);
            return View(oPINIA);
        }

        // GET: OPINIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPINIA oPINIA = db.OPINIA.Find(id);
            if (oPINIA == null)
            {
                return HttpNotFound();
            }
            return View(oPINIA);
        }

        // POST: OPINIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OPINIA oPINIA = db.OPINIA.Find(id);
            db.OPINIA.Remove(oPINIA);
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
