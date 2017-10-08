using DLS_Technologies.Models.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DLS_Technologies.ViewModels.CustomerViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }        

        public IEnumerable<AccountType> AccountTypes { get; set; }

        [Required]
        [Display(Name = "Account Type")]
        public byte AccountTypeId { get; set; }

        [Required]
        [Display(Name = "Date Joined")]
        public DateTime DateJoined { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [Required]
        [Display(Name = "Contact Information")]
        public string ContactInfo { get; set; }

        [Display(Name = "Notes")]
        public CustomerNote CustomerNote { get; set; }

        [Display(Name = "Notes")]
        public string InitialNote { get; set; }


    }
}