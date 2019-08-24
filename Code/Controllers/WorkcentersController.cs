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
    public class WorkcentersController : Controller
    {
        private Entities db = new Entities();

        // GET: Workcenters
        public ActionResult Index()
        {
            return View(db.Workcenters.ToList());
        }

        // GET: Workcenters/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workcenter workcenter = db.Workcenters.Find(id);
            if (workcenter == null)
            {
                return HttpNotFound();
            }
            return View(workcenter);
        }

        // GET: Workcenters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workcenters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkCenterID,WorkCenterLocation")] Workcenter workcenter)
        {
            if (ModelState.IsValid)
            {
                db.Workcenters.Add(workcenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workcenter);
        }

        // GET: Workcenters/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workcenter workcenter = db.Workcenters.Find(id);
            if (workcenter == null)
            {
                return HttpNotFound();
            }
            return View(workcenter);
        }

        // POST: Workcenters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkCenterID,WorkCenterLocation")] Workcenter workcenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workcenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workcenter);
        }

        // GET: Workcenters/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workcenter workcenter = db.Workcenters.Find(id);
            if (workcenter == null)
            {
                return HttpNotFound();
            }
            return View(workcenter);
        }

        // POST: Workcenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Workcenter workcenter = db.Workcenters.Find(id);
            db.Workcenters.Remove(workcenter);
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
