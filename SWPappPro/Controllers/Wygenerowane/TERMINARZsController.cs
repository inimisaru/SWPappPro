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
    public class TERMINARZsController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();

        // GET: TERMINARZs
        public ActionResult Index()
        {
            var tERMINARZ = db.TERMINARZ.Include(t => t.LEKARZ);
            return View(tERMINARZ.ToList());
        }

        // GET: TERMINARZs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TERMINARZ tERMINARZ = db.TERMINARZ.Find(id);
            if (tERMINARZ == null)
            {
                return HttpNotFound();
            }
            return View(tERMINARZ);
        }

        // GET: TERMINARZs/Create
        public ActionResult Create()
        {
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE");
            return View();
        }

        // POST: TERMINARZs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TERMINARZ_ID,DATA,GODZINA,LEKARZ_ID")] TERMINARZ tERMINARZ)
        {
            if (ModelState.IsValid)
            {
                db.TERMINARZ.Add(tERMINARZ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", tERMINARZ.LEKARZ_ID);
            return View(tERMINARZ);
        }

        // GET: TERMINARZs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TERMINARZ tERMINARZ = db.TERMINARZ.Find(id);
            if (tERMINARZ == null)
            {
                return HttpNotFound();
            }
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", tERMINARZ.LEKARZ_ID);
            return View(tERMINARZ);
        }

        // POST: TERMINARZs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TERMINARZ_ID,DATA,GODZINA,LEKARZ_ID")] TERMINARZ tERMINARZ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tERMINARZ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LEKARZ_ID = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", tERMINARZ.LEKARZ_ID);
            return View(tERMINARZ);
        }

        // GET: TERMINARZs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TERMINARZ tERMINARZ = db.TERMINARZ.Find(id);
            if (tERMINARZ == null)
            {
                return HttpNotFound();
            }
            return View(tERMINARZ);
        }

        // POST: TERMINARZs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TERMINARZ tERMINARZ = db.TERMINARZ.Find(id);
            db.TERMINARZ.Remove(tERMINARZ);
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
