using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S2G7PVFAPPLATEST25.Models;

namespace S2G7PVFAPPLATEST25.Controllers
{
    public class RawmaterialsController : Controller
    {
        private Entities db = new Entities();

        // GET: Rawmaterials
        public ActionResult Index()
        {
            return View(db.Rawmaterials.ToList());
        }

        // GET: Rawmaterials/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rawmaterial rawmaterial = db.Rawmaterials.Find(id);
            if (rawmaterial == null)
            {
                return HttpNotFound();
            }
            return View(rawmaterial);
        }

        // GET: Rawmaterials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rawmaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaterialID,MaterialName,MaterialStandardCost,UnitofMeasure")] Rawmaterial rawmaterial)
        {
            if (ModelState.IsValid)
            {
                db.Rawmaterials.Add(rawmaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rawmaterial);
        }

        // GET: Rawmaterials/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rawmaterial rawmaterial = db.Rawmaterials.Find(id);
            if (rawmaterial == null)
            {
                return HttpNotFound();
            }
            return View(rawmaterial);
        }

        // POST: Rawmaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaterialID,MaterialName,MaterialStandardCost,UnitofMeasure")] Rawmaterial rawmaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rawmaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rawmaterial);
        }

        // GET: Rawmaterials/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rawmaterial rawmaterial = db.Rawmaterials.Find(id);
            if (rawmaterial == null)
            {
                return HttpNotFound();
            }
            return View(rawmaterial);
        }

        // POST: Rawmaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Rawmaterial rawmaterial = db.Rawmaterials.Find(id);
            db.Rawmaterials.Remove(rawmaterial);
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
