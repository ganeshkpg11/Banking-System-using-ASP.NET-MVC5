using Banking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Banking.Models;
using System.Security.Cryptography;
using System.Net.Sockets;

namespace Banking.Controllers
{
    public class FundsController : Controller
    {
        // GET: Funds
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "transid,withdraw,transferto")] Transaction_Tbl transaction_Tbl,string btn)
        {
            BankingSystem_DBEntities db = new BankingSystem_DBEntities();
            if (ModelState.IsValid)
            {
                if(btn == "Fund Transfer")
                {

                    transaction_Tbl.transferfrom = Convert.ToInt32(Session["Accno"]);
                    int accno = Convert.ToInt32(Session["Accno"]);
                    var data = db.Customer_Tbl.Where(o => o.accountno == accno).FirstOrDefault();
                    var datato = db.Customer_Tbl.Where(obj => obj.accountno == transaction_Tbl.transferto).FirstOrDefault();
                    //var datato = (from r in db.Transaction_Tbl
                    //              select r).FirstOrDefault();
                    if (transaction_Tbl.withdraw <= data.balance)
                    {
                        var value = data.balance - transaction_Tbl.withdraw;
                        data.balance = (decimal)value;
                        transaction_Tbl.balanceamt = (data.balance);

                        datato.balance = (decimal)(datato.balance + transaction_Tbl.withdraw);
                        Transaction_Tbl trans = new Transaction_Tbl();
                        trans.deposit = transaction_Tbl.withdraw;
                        trans.transferfrom = Convert.ToInt32(Session["Accno"]);
                        trans.transferto = transaction_Tbl.transferto;
                        trans.balanceamt = datato.balance;
                        //datato.balance = (decimal)value1;
                        db.Transaction_Tbl.Add(transaction_Tbl);
                        db.Transaction_Tbl.Add(trans);

                        int v = db.SaveChanges();
                        if (v < 0)
                        {
                            ViewBag.data = "Fund Transfer was UnSuccessful";
                        }
                        else
                        {
                            ViewBag.data = "Fund Transfer was Successful";
                        }
                    }
                    else
                    {
                        ViewBag.data = "Insufficent Amount! Please deposit money first";
                    }
                }
                //return RedirectToAction("Index","Home");
                else if (btn == "Check Balance")
                {
                    int accno = Convert.ToInt32(Session["Accno"]);

                    var data = db.Customer_Tbl.Where(o => o.accountno == accno).FirstOrDefault();
                    if (data == null)
                    {
                        ViewBag.data = "No Account Available with this Account Number!";

                    }
                    else
                    {
                        ViewBag.Show = data.balance;
                    }

                }

            }

            return View(transaction_Tbl);
        }
    }
}