using Banking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Banking.Controllers
{
    public class CustomerLoginController : Controller
    {
        BankingSystem_DBEntities db = new BankingSystem_DBEntities();
        // GET: CustomerLogin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                BankingSystem_DBEntities db = new BankingSystem_DBEntities();
                var user = (from userlist in db.Customer_Tbl
                            where userlist.UserName == login.username &&
                            userlist.Password == login.password
                            select new
                            {
                                userlist.UserName,
                                userlist.accountno
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {

                    Session["AccNo"] = user.FirstOrDefault().accountno;
                    Session["UserName"] = user.FirstOrDefault().UserName;
                    FormsAuthentication.SetAuthCookie(login.username, false);
                    return Redirect("/CustomerLogin/WelcomePage");
                }
                else
                {
                    ViewBag.Data = "Invalid Login Credentials";
                    return View();
                }
            }
            ModelState.Clear();
            return View(login);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult WelcomePage()
        {
            return View();
        }
        public ActionResult Signup()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Signup([Bind(Include = "full_name,contact_no,email,occupation,state,city,accounttype,pincode,address,UserName,Password")] Customer_Tbl obj)
        {
            if (ModelState.IsValid)
            {
                obj.balance = 0;
                db.Customer_Tbl.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(obj);
        }
    }
}