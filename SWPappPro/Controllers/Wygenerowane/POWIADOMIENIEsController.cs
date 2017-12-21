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
    public class POWIADOMIENIEsController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();

        // GET: POWIADOMIENIEs
        public ActionResult Index()
        {
            var pOWIADOMIENIE = db.POWIADOMIENIE.Include(p => p.LEKARZ).Include(p => p.PACJENT);
            return View(pOWIADOMIENIE.ToList());
        }

        // GET: POWIADOMIENIEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POWIADOMIENIE pOWIADOMIENIE = db.POWIADOMIENIE.Find(id);
            if (pOWIADOMIENIE == null)
            {
                return HttpNotFound();
            }
            return View(pOWIADOMIENIE);
        }

        // GET: POWIADOMIENIEs/Create
        public ActionResult Create()
        {
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE");
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE");
            return View();
        }

        // POST: POWIADOMIENIEs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "POWIADOMIENIE_ID,NUMER_POWIADOMIENIA,TRESC,PACJENT_ID,LEKARZ_ID,STATUS")] POWIADOMIENIE pOWIADOMIENIE)
        {
            if (ModelState.IsValid)
            {
                db.POWIADOMIENIE.Add(pOWIADOMIENIE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", pOWIADOMIENIE.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", pOWIADOMIENIE.PACJENT_ID);
            return View(pOWIADOMIENIE);
        }

        // GET: POWIADOMIENIEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POWIADOMIENIE pOWIADOMIENIE = db.POWIADOMIENIE.Find(id);
            if (pOWIADOMIENIE == null)
            {
                return HttpNotFound();
            }
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", pOWIADOMIENIE.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", pOWIADOMIENIE.PACJENT_ID);
            return View(pOWIADOMIENIE);
        }

        // POST: POWIADOMIENIEs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "POWIADOMIENIE_ID,NUMER_POWIADOMIENIA,TRESC,PACJENT_ID,LEKARZ_ID,STATUS")] POWIADOMIENIE pOWIADOMIENIE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pOWIADOMIENIE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", pOWIADOMIENIE.LEKARZ_ID);
            ViewBag.PACJENT_ID = new SelectList(db.PACJENT, "PACJENT_ID", "IMIE", pOWIADOMIENIE.PACJENT_ID);
            return View(pOWIADOMIENIE);
        }

        // GET: POWIADOMIENIEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POWIADOMIENIE pOWIADOMIENIE = db.POWIADOMIENIE.Find(id);
            if (pOWIADOMIENIE == null)
            {
                return HttpNotFound();
            }
            return View(pOWIADOMIENIE);
        }

        // POST: POWIADOMIENIEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POWIADOMIENIE pOWIADOMIENIE = db.POWIADOMIENIE.Find(id);
            db.POWIADOMIENIE.Remove(pOWIADOMIENIE);
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
