using DLS_Technologies.Models.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DLS_Technologies.ViewModels.CustomerViewModels
{
    public class CustomerNotesViewModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string Note { get; set; }

        [Display(Name = "Notes:")]
        public IEnumerable<CustomerNote> Notes { get; set; }
    }
}