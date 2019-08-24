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
    public class InvoiceController : Controller
    {
        private Entities db = new Entities();

        // GET: Invoice
        public ActionResult Index()
        {
            return View(db.Productlines.ToList());
        }

        // GET: Invoice/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productline productline = db.Productlines.Find(id);
            if (productline == null)
            {
                return HttpNotFound();
            }
            return View(productline);
        }

        // GET: Invoice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invoice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductLineID,ProductLineName")] Productline productline)
        {
            if (ModelState.IsValid)
            {
                db.Productlines.Add(productline);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productline);
        }

        // GET: Invoice/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productline productline = db.Productlines.Find(id);
            if (productline == null)
            {
                return HttpNotFound();
            }
            return View(productline);
        }

        // POST: Invoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductLineID,ProductLineName")] Productline productline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productline);
        }

        // GET: Invoice/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productline productline = db.Productlines.Find(id);
            if (productline == null)
            {
                return HttpNotFound();
            }
            return View(productline);
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Productline productline = db.Productlines.Find(id);
            db.Productlines.Remove(productline);
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
