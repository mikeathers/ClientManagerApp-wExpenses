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
        [Display(Name = "Name:")]
        public string Name { get; set; }        

        public IEnumerable<AccountType> AccountTypes { get; set; }

        [Required]
        [Display(Name = "Account Type:")]
        public byte AccountTypeId { get; set; }

        public AccountType AccountType { get; set; }

        [Required]
        [Display(Name = "Contact on Site:")]
        public string ContactOnSite { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Date Joined:")]
        public DateTime DateJoined { get; set; }

        [Required]
        [Display(Name = "Address:")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Post Code:")]
        public string PostCode { get; set; }

        [Required]
        [Display(Name = "Contact Information:")]
        public string ContactInfo { get; set; }

        [Display(Name = "Notes:")]
        public CustomerNote CustomerNote { get; set; }
        

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Site Visit Date:")]
        public DateTime? MonthlySiteVisitDate { get; set; }

        [Display(Name = "Site Visit:")]
        public bool? MonthlySiteVisitDue { get; set; }

        [Display(Name = "Notes:")]
        public IEnumerable<CustomerNote> Notes { get; set; }

        [Display(Name = "Notes:")]
        public string Note { get; set; }
    }


    
}