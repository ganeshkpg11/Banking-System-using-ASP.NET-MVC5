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
    
    public partial class Transaction_Tbl
    {
        public int transid { get; set; }
        public Nullable<int> accountno { get; set; }
        public Nullable<decimal> withdraw { get; set; }
        public Nullable<decimal> deposit { get; set; }
        public Nullable<int> transferfrom { get; set; }
        public Nullable<int> transferto { get; set; }
        public Nullable<decimal> balanceamt { get; set; }
    }
}
