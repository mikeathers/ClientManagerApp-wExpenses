using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DLS_Technologies.Models.Customers
{
    public class CustomerNote
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "New Note:")]
        public string Note { get; set; }

        public Customer Customer { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }


    }
}