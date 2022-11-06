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
    public class Branch_TblController : Controller
    {
        private BankingSystem_DBEntities db = new BankingSystem_DBEntities();

        // GET: Branch_Tbl
        public ActionResult Index()
        {
            return View(db.Branch_Tbl.ToList());
        }

        // GET: Branch_Tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch_Tbl branch_Tbl = db.Branch_Tbl.Find(id);
            if (branch_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(branch_Tbl);
        }

        // GET: Branch_Tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Branch_Tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "branchid,branch_name,ifsc_code,location,city")] Branch_Tbl branch_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Branch_Tbl.Add(branch_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(branch_Tbl);
        }

        // GET: Branch_Tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch_Tbl branch_Tbl = db.Branch_Tbl.Find(id);
            if (branch_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(branch_Tbl);
        }

        // POST: Branch_Tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "branchid,branch_name,ifsc_code,location,city")] Branch_Tbl branch_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branch_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branch_Tbl);
        }

        // GET: Branch_Tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch_Tbl branch_Tbl = db.Branch_Tbl.Find(id);
            if (branch_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(branch_Tbl);
        }

        // POST: Branch_Tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Branch_Tbl branch_Tbl = db.Branch_Tbl.Find(id);
            db.Branch_Tbl.Remove(branch_Tbl);
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
