using Banking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Banking.Controllers
{
    public class MyTransController : Controller
    {
        BankingSystem_DBEntities db = new BankingSystem_DBEntities();

        // GET: MyTrans
        [Authorize]
        //public ActionResult Index()
        //{
        //    return View(/*db.Transaction_Tbl.ToList()*/);
        //}
        //[HttpPost]
        public ActionResult Index()
        {
            
            int accno = Convert.ToInt32(Session["Accno"]);
            var data = (from r in db.Transaction_Tbl
                        where r.accountno == accno || r.transferfrom==accno|| r.transferto==accno
                        select r).ToList();
            return View(data);

            
        }
    }
}