using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GdzieIzKim.DAL;
using GdzieIzKim.Models;

namespace GdzieIzKim.Controllers
{
    public class LokController : Controller
    {
        private gdzieDB db = new gdzieDB();

        // GET: Lok
        public ActionResult Index()
        {
            var lokalizacja = db.Lokalizacja.Include(l => l.Kategoria);
            return View(lokalizacja.ToList());
        }

        // GET: Lok/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokalizacja lokalizacja = db.Lokalizacja.Find(id);
            if (lokalizacja == null)
            {
                return HttpNotFound();
            }
            return View(lokalizacja);
        }

        // GET: Lok/Create
        public ActionResult Create()
        {
            ViewBag.KategoriaId = new SelectList(db.Kategoria, "KategoriaId", "NazwaKat");
            return View();
        }

        // POST: Lok/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LokalizacjaId,NazwaLoc,AdresLoc,InformacjeLoc,SzerokoscLoc,DlugoscLoc,KategoriaId")] Lokalizacja lokalizacja)
        {
            if (ModelState.IsValid)
            {
                db.Lokalizacja.Add(lokalizacja);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.KategoriaId = new SelectList(db.Kategoria, "KategoriaId", "NazwaKat", lokalizacja.KategoriaId);
            return View(lokalizacja);
        }

        // GET: Lok/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokalizacja lokalizacja = db.Lokalizacja.Find(id);
            if (lokalizacja == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriaId = new SelectList(db.Kategoria, "KategoriaId", "NazwaKat", lokalizacja.KategoriaId);
            return View(lokalizacja);
        }

        // POST: Lok/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LokalizacjaId,NazwaLoc,AdresLoc,InformacjeLoc,SzerokoscLoc,DlugoscLoc,KategoriaId")] Lokalizacja lokalizacja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lokalizacja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriaId = new SelectList(db.Kategoria, "KategoriaId", "NazwaKat", lokalizacja.KategoriaId);
            return View(lokalizacja);
        }

        // GET: Lok/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokalizacja lokalizacja = db.Lokalizacja.Find(id);
            if (lokalizacja == null)
            {
                return HttpNotFound();
            }
            return View(lokalizacja);
        }

        // POST: Lok/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lokalizacja lokalizacja = db.Lokalizacja.Find(id);
            db.Lokalizacja.Remove(lokalizacja);
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
