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
    public class Loandetail_TblController : Controller
    {
       
        private BankingSystem_DBEntities db = new BankingSystem_DBEntities();

        // GET: Loandetail_Tbl
        [Authorize]
        public ActionResult Index()
        {
            var loandetail_Tbl = db.Loandetail_Tbl.Include(l => l.Loan_Tbl);
            return View(loandetail_Tbl.ToList());
        }
        public ActionResult Index1()
        {
            var loandetail_Tbl = db.Loandetail_Tbl.Include(l => l.Loan_Tbl);
            return View(loandetail_Tbl.ToList());
        }


        // GET: Loandetail_Tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loandetail_Tbl loandetail_Tbl = db.Loandetail_Tbl.Find(id);
            if (loandetail_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(loandetail_Tbl);
        }

        // GET: Loandetail_Tbl/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.loanid = new SelectList(db.Loan_Tbl, "loanid", "loanid");
            return View();
        }

        // POST: Loandetail_Tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,loanid")] Loandetail_Tbl loandetail_Tbl)
        {
            if (ModelState.IsValid)
            {
                loandetail_Tbl.accountno = Convert.ToInt32(Session["Accno"]);   
                db.Loandetail_Tbl.Add(loandetail_Tbl);
                db.SaveChanges();
              
                return RedirectToAction("Index1");
            }

            ViewBag.loanid = new SelectList(db.Loan_Tbl, "loanid", "type", loandetail_Tbl.loanid);
            return View(loandetail_Tbl);
        }

        // GET: Loandetail_Tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loandetail_Tbl loandetail_Tbl = db.Loandetail_Tbl.Find(id);
            if (loandetail_Tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.loanid = new SelectList(db.Loan_Tbl, "loanid", "type", loandetail_Tbl.loanid);
            return View(loandetail_Tbl);
        }

        // POST: Loandetail_Tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,loanid,accountno")] Loandetail_Tbl loandetail_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loandetail_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.loanid = new SelectList(db.Loan_Tbl, "loanid", "type", loandetail_Tbl.loanid);
            return View(loandetail_Tbl);
        }

        // GET: Loandetail_Tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loandetail_Tbl loandetail_Tbl = db.Loandetail_Tbl.Find(id);
            if (loandetail_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(loandetail_Tbl);
        }

        // POST: Loandetail_Tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loandetail_Tbl loandetail_Tbl = db.Loandetail_Tbl.Find(id);
            db.Loandetail_Tbl.Remove(loandetail_Tbl);
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
