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
    public class Transaction_TblController : Controller
    {
        private BankingSystem_DBEntities db = new BankingSystem_DBEntities();

        // GET: Transaction_Tbl
        public ActionResult Index()
        {
            return View(db.Transaction_Tbl.ToList());
        }

        // GET: Transaction_Tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction_Tbl transaction_Tbl = db.Transaction_Tbl.Find(id);
            if (transaction_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(transaction_Tbl);
        }

        // GET: Transaction_Tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaction_Tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "transid,accountno,withdraw,deposit,transferfrom,transferto,balanceamt")] Transaction_Tbl transaction_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Transaction_Tbl.Add(transaction_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transaction_Tbl);
        }

        // GET: Transaction_Tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction_Tbl transaction_Tbl = db.Transaction_Tbl.Find(id);
            if (transaction_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(transaction_Tbl);
        }

        // POST: Transaction_Tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "transid,accountno,withdraw,deposit,transferfrom,transferto,balanceamt")] Transaction_Tbl transaction_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction_Tbl);
        }

        // GET: Transaction_Tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction_Tbl transaction_Tbl = db.Transaction_Tbl.Find(id);
            if (transaction_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(transaction_Tbl);
        }

        // POST: Transaction_Tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction_Tbl transaction_Tbl = db.Transaction_Tbl.Find(id);
            db.Transaction_Tbl.Remove(transaction_Tbl);
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
