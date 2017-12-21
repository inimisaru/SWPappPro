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
    public class GABINETsController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();

        // GET: GABINETs
        public ActionResult Index()
        {
            var gABINET = db.GABINET.Include(g => g.LEKARZ).Where(g => g.LEKARZ.LEKARZ_ID.Equals(Session["id"]));
            return View(gABINET.ToList());
        }

        // GET: GABINETs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GABINET gABINET = db.GABINET.Find(id);
            if (gABINET == null)
            {
                return HttpNotFound();
            }
            return View(gABINET);
        }

        // GET: GABINETs/Create
        public ActionResult Create()
        {
            ViewBag.LEKARZ_ODPOWIEDZIALNY = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE");
            return View();
        }

        // POST: GABINETs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NR,BUDYNEK,RODZAJ,GABINET_ID,LEKARZ_ODPOWIEDZIALNY")] GABINET gABINET)
        {
            if (ModelState.IsValid)
            {
                db.GABINET.Add(gABINET);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LEKARZ_ODPOWIEDZIALNY = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", gABINET.LEKARZ_ODPOWIEDZIALNY);
            return View(gABINET);
        }

        // GET: GABINETs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GABINET gABINET = db.GABINET.Find(id);
            if (gABINET == null)
            {
                return HttpNotFound();
            }
            ViewBag.LEKARZ_ODPOWIEDZIALNY = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", gABINET.LEKARZ_ODPOWIEDZIALNY);
            return View(gABINET);
        }

        // POST: GABINETs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NR,BUDYNEK,RODZAJ,GABINET_ID,LEKARZ_ODPOWIEDZIALNY")] GABINET gABINET)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gABINET).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LEKARZ_ODPOWIEDZIALNY = new SelectList(db.LEKARZ, "LEKARZ_ID", "IMIE", gABINET.LEKARZ_ODPOWIEDZIALNY);
            return View(gABINET);
        }

        // GET: GABINETs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GABINET gABINET = db.GABINET.Find(id);
            if (gABINET == null)
            {
                return HttpNotFound();
            }
            return View(gABINET);
        }

        // POST: GABINETs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GABINET gABINET = db.GABINET.Find(id);
            db.GABINET.Remove(gABINET);
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
