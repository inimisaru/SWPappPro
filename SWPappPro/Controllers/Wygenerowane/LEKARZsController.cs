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
    public class LEKARZsController : Controller
    {
        private SWPappDBEntities db = new SWPappDBEntities();

        // GET: LEKARZs
        public ActionResult Index()
        {
            return View(db.LEKARZ.ToList());
        }

        // GET: LEKARZs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LEKARZ lEKARZ = db.LEKARZ.Find(id);
            if (lEKARZ == null)
            {
                return HttpNotFound();
            }
            return View(lEKARZ);
        }

        // GET: LEKARZs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LEKARZs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LEKARZ_ID,IMIE,NAZWISKO,SPECJALIZACJA,PESEL,DATA_URODZENIA,NR_LICENCJI,HASLO")] LEKARZ lEKARZ)
        {
            if (ModelState.IsValid)
            {
                db.LEKARZ.Add(lEKARZ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lEKARZ);
        }

        // GET: LEKARZs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LEKARZ lEKARZ = db.LEKARZ.Find(id);
            if (lEKARZ == null)
            {
                return HttpNotFound();
            }
            return View(lEKARZ);
        }

        // POST: LEKARZs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LEKARZ_ID,IMIE,NAZWISKO,SPECJALIZACJA,PESEL,DATA_URODZENIA,NR_LICENCJI,HASLO")] LEKARZ lEKARZ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lEKARZ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lEKARZ);
        }

        // GET: LEKARZs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LEKARZ lEKARZ = db.LEKARZ.Find(id);
            if (lEKARZ == null)
            {
                return HttpNotFound();
            }
            return View(lEKARZ);
        }

        // POST: LEKARZs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LEKARZ lEKARZ = db.LEKARZ.Find(id);
            db.LEKARZ.Remove(lEKARZ);
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
