using Banking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Banking.Models;

namespace Banking.Controllers
{
    public class TransactionsController : Controller
    {
        BankingSystem_DBEntities db = new BankingSystem_DBEntities();
        // GET: Transactions
        public ActionResult Index()
        {

           return View();
        }
        [HttpPost]
        public ActionResult Index(Transaction_Tbl obj, string btn)
        {
            if(btn=="Withdraw")
            {
                var data = db.Customer_Tbl.Where(o => o.accountno == obj.accountno).FirstOrDefault();
                if(obj.withdraw<=data.balance)
                {
                    var value = data.balance - obj.withdraw;
                    data.balance = (decimal)value;
                    obj.balanceamt = (int?)data.balance;
                    db.Transaction_Tbl.Add(obj);
                    int v=db.SaveChanges();
                    if(v>0)
                    {
                        ViewBag.data = "Withdraw was Successful";
                    }
                    else
                    {
                        ViewBag.data = "Withdraw was UnSuccessful";
                    }
                }
                else
                {
                    ViewBag.data = "Insufficent Amount! Please deposit money first";
                }
            }
            else if(btn=="Deposit")
            {
                var data = db.Customer_Tbl.Where(o => o.accountno == obj.accountno).FirstOrDefault();
                //data.balance = (decimal)(data.balance + obj.withdraw);
                //data.balance = (decimal)value;
                var value = data.balance + obj.deposit;
                data.balance = (decimal)value;
                obj.balanceamt = data.balance;
                db.Transaction_Tbl.Add(obj);
                int v = db.SaveChanges();
                if (v > 0)
                {
                    ViewBag.data = "Deposit was Successful";
                }
                else
                {
                    ViewBag.data = "deposit was UnSuccessful";
                }
            }
            else if(btn=="Check")
            {
                
                var data = db.Customer_Tbl.Where(o => o.accountno == obj.accountno).FirstOrDefault();
                if(data == null)
                {
                    ViewBag.data = "No Account Available with this Account Number!";
                  
                }
                else
                {
                    ViewBag.Show = data.balance;
                }
                
            }
           
            return View(obj);
        }
        public ActionResult Home()
        {

            return RedirectToAction("Index", "Home");
        }

    }
}