using Banking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Banking.Controllers
{
    public class MyAccountController : Controller
    {     
        // GET: MyAccount
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult CustomerEdit()
        {
            int accno = Convert.ToInt32(Session["AccNo"].ToString());
            TempData["accountno"]=accno;
            BankingSystem_DBEntities db=new BankingSystem_DBEntities();
            Customer_Tbl customer = db.Customer_Tbl.Find(accno);
            if(customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        // POST: Customer_Tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerEdit([Bind(Include = "accountno,full_name,contact_no,email,occupation,state,city,accounttype,pincode,address,UserName,Password")] Customer_Tbl customer_Tbl)
        {
            BankingSystem_DBEntities db = new BankingSystem_DBEntities();
            if (ModelState.IsValid)
            {
                
                db.Entry(customer_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WelcomePage","CustomerLogin");
            }
            return View(customer_Tbl);
        }

    }
}