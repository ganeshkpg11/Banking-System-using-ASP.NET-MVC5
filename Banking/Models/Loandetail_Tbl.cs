//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Banking.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Loandetail_Tbl
    {
        public int id { get; set; }
        public Nullable<int> loanid { get; set; }
        public Nullable<int> accountno { get; set; }
    
        public virtual Loan_Tbl Loan_Tbl { get; set; }
    }
}
