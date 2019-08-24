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
    public class SalespersonsController : Controller
    {
        private Entities db = new Entities();

        // GET: Salespersons
        public ActionResult Index()
        {
            var salespersons = db.Salespersons.Include(s => s.Territory);
            return View(salespersons.ToList());
        }

        // GET: Salespersons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesperson salesperson = db.Salespersons.Find(id);
            if (salesperson == null)
            {
                return HttpNotFound();
            }
            return View(salesperson);
        }

        // GET: Salespersons/Create
        public ActionResult Create()
        {
            ViewBag.TerritoryID = new SelectList(db.Territories, "TerritoryID", "TerritoryName");
            return View();
        }

        // POST: Salespersons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalespersonID,SalespersonName,SalespersonTelephone,SalespersonFax,TerritoryID")] Salesperson salesperson)
        {
            if (ModelState.IsValid)
            {
                db.Salespersons.Add(salesperson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TerritoryID = new SelectList(db.Territories, "TerritoryID", "TerritoryName", salesperson.TerritoryID);
            return View(salesperson);
        }

        // GET: Salespersons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesperson salesperson = db.Salespersons.Find(id);
            if (salesperson == null)
            {
                return HttpNotFound();
            }
            ViewBag.TerritoryID = new SelectList(db.Territories, "TerritoryID", "TerritoryName", salesperson.TerritoryID);
            return View(salesperson);
        }

        // POST: Salespersons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalespersonID,SalespersonName,SalespersonTelephone,SalespersonFax,TerritoryID")] Salesperson salesperson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesperson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TerritoryID = new SelectList(db.Territories, "TerritoryID", "TerritoryName", salesperson.TerritoryID);
            return View(salesperson);
        }

        // GET: Salespersons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesperson salesperson = db.Salespersons.Find(id);
            if (salesperson == null)
            {
                return HttpNotFound();
            }
            return View(salesperson);
        }

        // POST: Salespersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Salesperson salesperson = db.Salespersons.Find(id);
            db.Salespersons.Remove(salesperson);
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
