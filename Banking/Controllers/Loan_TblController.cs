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
    public class Loan_TblController : Controller
    {
        private BankingSystem_DBEntities db = new BankingSystem_DBEntities();

        // GET: Loan_Tbl
        public ActionResult Index()
        {
            return View(db.Loan_Tbl.ToList());
        }

        // GET: Loan_Tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan_Tbl loan_Tbl = db.Loan_Tbl.Find(id);
            if (loan_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(loan_Tbl);
        }

        // GET: Loan_Tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Loan_Tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "loanid,type,amount,interest,duration")] Loan_Tbl loan_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Loan_Tbl.Add(loan_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loan_Tbl);
        }

        // GET: Loan_Tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan_Tbl loan_Tbl = db.Loan_Tbl.Find(id);
            if (loan_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(loan_Tbl);
        }

        // POST: Loan_Tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "loanid,type,amount,interest,duration")] Loan_Tbl loan_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loan_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loan_Tbl);
        }

        // GET: Loan_Tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan_Tbl loan_Tbl = db.Loan_Tbl.Find(id);
            if (loan_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(loan_Tbl);
        }

        // POST: Loan_Tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loan_Tbl loan_Tbl = db.Loan_Tbl.Find(id);
            db.Loan_Tbl.Remove(loan_Tbl);
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
