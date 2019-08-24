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
    public class supplierdetailsController : Controller
    {
        private Entities db = new Entities();

        // GET: supplierdetails
        public ActionResult Index()
        {
            return View(db.supplierdetails.ToList());
        }

        // GET: supplierdetails/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            supplierdetail supplierdetail = db.supplierdetails.Find(id);
            if (supplierdetail == null)
            {
                return HttpNotFound();
            }
            return View(supplierdetail);
        }

        // GET: supplierdetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: supplierdetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductDescription,MaterialName,VendorName,VendorAddress")] supplierdetail supplierdetail)
        {
            if (ModelState.IsValid)
            {
                db.supplierdetails.Add(supplierdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplierdetail);
        }

        // GET: supplierdetails/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            supplierdetail supplierdetail = db.supplierdetails.Find(id);
            if (supplierdetail == null)
            {
                return HttpNotFound();
            }
            return View(supplierdetail);
        }

        // POST: supplierdetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductDescription,MaterialName,VendorName,VendorAddress")] supplierdetail supplierdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplierdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplierdetail);
        }

        // GET: supplierdetails/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            supplierdetail supplierdetail = db.supplierdetails.Find(id);
            if (supplierdetail == null)
            {
                return HttpNotFound();
            }
            return View(supplierdetail);
        }

        // POST: supplierdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            supplierdetail supplierdetail = db.supplierdetails.Find(id);
            db.supplierdetails.Remove(supplierdetail);
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
