using Banking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

[assembly: CLSCompliant(true)]
namespace Banking.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
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
                var user = (from userlist in db.Admin_Tbl
                            where userlist.UserName == login.username &&
                            userlist.Password == login.password
                            select new
                            {
                                userlist.UserName,
                                
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {

                    Session["UserName"] = user.FirstOrDefault().UserName;
                    FormsAuthentication.SetAuthCookie(login.username, false);
                    return RedirectToAction("WelcomePage");
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
            return RedirectToAction("Index","Home");
        }
        public ActionResult WelcomePage()
        {
            return View();
        }
    }
}