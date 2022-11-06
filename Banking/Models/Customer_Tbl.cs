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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class CustomerLoginModel
    {
        [Required(ErrorMessage = "Please enter username")]
        [Display(Name = "User name")]
        [StringLength(30)]
        public string username { get; set; }
        [Required(ErrorMessage = "Please enter the password")]
        [DataType(DataType.Password)]
        [StringLength(10)]
        public string password { get; set; }

    }
    public partial class Customer_Tbl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int accountno { get; set; }
        [Required(ErrorMessage ="Required")]
        public string full_name { get; set; }
        [Required(ErrorMessage = "Required")]
        public string contact_no { get; set; }
        [Required(ErrorMessage = "Required")]
        public string email { get; set; }
        [Required(ErrorMessage = "Required")]
        public string occupation { get; set; }
        [Required(ErrorMessage = "Required")]
        public string state { get; set; }
        [Required(ErrorMessage = "Required")]
        public string city { get; set; }
        [Required(ErrorMessage = "Required")]
        public string accounttype { get; set; }
        [Required(ErrorMessage = "Required")]
        public string pincode { get; set; }
        [Required(ErrorMessage = "Required")]
        public string address { get; set; }
        [Required(ErrorMessage = "Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }
        public decimal balance { get; set; }
    }
}
