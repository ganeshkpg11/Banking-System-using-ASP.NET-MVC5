using Banking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Banking.Controllers
{
    public class LoanDetailsController : Controller
    {
        // GET: LoanDetails
        public ActionResult Index()
        {
            BankingSystem_DBEntities db = new BankingSystem_DBEntities();
            
            return View(db.Loandetail_Tbl.ToList());
        }
    }
}