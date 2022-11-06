using System;
using System.Linq;
using Xunit;
using Banking;
using Banking.Models;
using System.Web.Mvc;

namespace UnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            BankingSystem_DBEntities db = new BankingSystem_DBEntities();
            Loan_Tbl Lt = new Loan_Tbl();
            Lt.loanid = 104;
            Lt.interest = 1.5;
            Lt.amount = 100000;
            Lt.type = "Study";
            Lt.duration = 20;
            db.Loan_Tbl.Add(Lt);

            int totalRows = db.SaveChanges();
            Assert.True(totalRows > 0 ? true : false);
        }
    }
}
