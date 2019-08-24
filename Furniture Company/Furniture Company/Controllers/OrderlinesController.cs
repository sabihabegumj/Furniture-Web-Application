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
    public class OrderlinesController : Controller
    {
        private Entities db = new Entities();

        // GET: Orderlines
        public ActionResult Index()
        {
            var orderlines = db.Orderlines.Include(o => o.Order).Include(o => o.Product);
            return View(orderlines.ToList());
        }

        // GET: Orderlines/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderline orderline = db.Orderlines.Find(id);
            if (orderline == null)
            {
                return HttpNotFound();
            }
            return View(orderline);
        }

        // GET: Orderlines/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "CustomerID");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductDescription");
            return View();
        }

        // POST: Orderlines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,ProductID,OrderedQuantity")] Orderline orderline)
        {
            if (ModelState.IsValid)
            {
                db.Orderlines.Add(orderline);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "CustomerID", orderline.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductDescription", orderline.ProductID);
            return View(orderline);
        }

        // GET: Orderlines/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderline orderline = db.Orderlines.Find(id);
            if (orderline == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "CustomerID", orderline.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductDescription", orderline.ProductID);
            return View(orderline);
        }

        // POST: Orderlines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,ProductID,OrderedQuantity")] Orderline orderline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "CustomerID", orderline.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductDescription", orderline.ProductID);
            return View(orderline);
        }

        // GET: Orderlines/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderline orderline = db.Orderlines.Find(id);
            if (orderline == null)
            {
                return HttpNotFound();
            }
            return View(orderline);
        }

        // POST: Orderlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Orderline orderline = db.Orderlines.Find(id);
            db.Orderlines.Remove(orderline);
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
