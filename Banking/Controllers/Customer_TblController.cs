using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Banking.Models;

namespace Banking.Controllers
{
    public class Customer_TblController : Controller
    {
        private BankingSystem_DBEntities db = new BankingSystem_DBEntities();

        // GET: Customer_Tbl
        public ActionResult Index()
        {
            return View(db.Customer_Tbl.ToList());
        }

        // GET: Customer_Tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Tbl customer_Tbl = db.Customer_Tbl.Find(id);
            if (customer_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(customer_Tbl);
        }

        // GET: Customer_Tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer_Tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "accountno,full_name,contact_no,email,occupation,state,city,accounttype,pincode,address,UserName,Password")] Customer_Tbl customer_Tbl)
        {
            if (ModelState.IsValid)
            {
                customer_Tbl.balance = 0;
                db.Customer_Tbl.Add(customer_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer_Tbl);
        }

        // GET: Customer_Tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Tbl customer_Tbl = db.Customer_Tbl.Find(id);
            if (customer_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(customer_Tbl);
        }

        // POST: Customer_Tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "accountno,full_name,contact_no,email,occupation,state,city,accounttype,pincode,address,UserName,Password,balance")] Customer_Tbl customer_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer_Tbl);
        }

        // GET: Customer_Tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Tbl customer_Tbl = db.Customer_Tbl.Find(id);
            if (customer_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(customer_Tbl);
        }

        // POST: Customer_Tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer_Tbl customer_Tbl = db.Customer_Tbl.Find(id);
            db.Customer_Tbl.Remove(customer_Tbl);
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
