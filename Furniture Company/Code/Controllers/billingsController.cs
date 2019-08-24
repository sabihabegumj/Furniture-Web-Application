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
    public class billingsController : Controller
    {
        private Entities db = new Entities();

        // GET: billings
        public ActionResult Index()
        {
            return View(db.billings.ToList());
        }

        // GET: billings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billing billing = db.billings.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // GET: billings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: billings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,CustomerName,CustomerAddress,CustomerPostalCode,OrderId,OrderDate,OrderedQuantity,ProductID,ProductDescription,ProductFinish,ProductStandardPrice,ProductLineName")] billing billing)
        {
            if (ModelState.IsValid)
            {
                db.billings.Add(billing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(billing);
        }

        // GET: billings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billing billing = db.billings.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // POST: billings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CustomerName,CustomerAddress,CustomerPostalCode,OrderId,OrderDate,OrderedQuantity,ProductID,ProductDescription,ProductFinish,ProductStandardPrice,ProductLineName")] billing billing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(billing);
        }

        // GET: billings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billing billing = db.billings.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // POST: billings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            billing billing = db.billings.Find(id);
            db.billings.Remove(billing);
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
